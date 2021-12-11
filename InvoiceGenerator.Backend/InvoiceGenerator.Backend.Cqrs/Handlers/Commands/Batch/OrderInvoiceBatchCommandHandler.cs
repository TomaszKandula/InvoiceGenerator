namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batch
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Database;
    using VatService;
    using UserService;
    using BatchService;
    using Core.Exceptions;
    using Shared.Resources;
    using VatService.Models;
    using BatchService.Models;
    using Core.Services.DateTimeService;

    public class OrderInvoiceBatchCommandHandler : RequestHandler<OrderInvoiceBatchCommand, OrderInvoiceBatchCommandResult>
    {
        private readonly DatabaseContext _databaseContext;
        
        private readonly IBatchService _batchService;

        private readonly IVatService _vatService;

        private readonly IUserService _userService;

        private readonly IDateTimeService _dateTimeService;

        public OrderInvoiceBatchCommandHandler(DatabaseContext databaseContext, IBatchService batchService, 
            IVatService vatService, IUserService userService, IDateTimeService dateTimeService)
        {
            _databaseContext = databaseContext;
            _batchService = batchService;
            _vatService = vatService;
            _userService = userService;
            _dateTimeService = dateTimeService;
        }

        public override async Task<OrderInvoiceBatchCommandResult> Handle(OrderInvoiceBatchCommand request, CancellationToken cancellationToken)
        {
            var isKeyValid = await _userService.IsPrivateKeyValid(request.PrivateKey, cancellationToken);
            var userId = await _userService.GetUserByPrivateKey(request.PrivateKey, cancellationToken);

            VerifyArguments(isKeyValid, userId);

            var vatOptions = new PolishVatNumberOptions(true, true);
            var vatPatterns = await _databaseContext.VatNumberPatterns
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var availableTemplates = await _databaseContext.InvoiceTemplates
                .AsNoTracking()
                .Where(templates => !templates.IsDeleted)
                .ToListAsync(cancellationToken);
            
            var order = new List<OrderDetail>();
            var items = new List<InvoiceItem>();
            foreach (var orderDetails in request.OrderDetails)
            {
                var vatCheckRequest = new VatValidationRequest(orderDetails.CompanyVatNumber, vatPatterns, vatOptions);
                var vatCheckResult = _vatService.ValidateVatNumber(vatCheckRequest);

                if (!vatCheckResult.IsValid)
                    throw new ValidationException(vatCheckResult, ValidationCodes.INVALID_VAT);

                foreach (var item in orderDetails.InvoiceItems)
                {
                    var valueAmount = GetValueAmount(item.ItemQuantity, item.ItemAmount, item.ItemDiscountRate);
                    var grossAmount = GetGrossAmount(valueAmount, item.VatRate);

                    items.Add(new InvoiceItem
                    {
                        ItemText = item.ItemText,
                        ItemQuantity = item.ItemQuantity,
                        ItemQuantityUnit = item.ItemQuantityUnit,
                        ItemAmount = item.ItemAmount,
                        ItemDiscountRate = item.ItemDiscountRate,
                        ValueAmount = valueAmount,
                        VatRate = item.VatRate,
                        GrossAmount = grossAmount,
                        CurrencyCode = item.CurrencyCode
                    });
                }

                CheckVoucherDateAndValueDate(orderDetails.VoucherDate, orderDetails.ValueDate);

                var voucherDate = orderDetails.VoucherDate ?? _dateTimeService.Now;
                var valueDate = orderDetails.ValueDate ?? _dateTimeService.Now;

                var isTemplateExists = availableTemplates
                    .Any(templates => templates.Name == orderDetails.InvoiceTemplateName);
                if (!isTemplateExists)
                    throw new BusinessException(nameof(ErrorCodes.INVALID_TEMPLATE_NAME), ErrorCodes.INVALID_TEMPLATE_NAME);

                order.Add(new OrderDetail
                {
                    UserId = userId,
                    InvoiceNumber = Guid.NewGuid().ToString("N"),
                    VoucherDate = voucherDate,
                    ValueDate = valueDate,
                    DueDate = valueDate.AddDays(orderDetails.PaymentTerms),
                    PaymentTerms = orderDetails.PaymentTerms,
                    PaymentType = orderDetails.PaymentType,
                    CompanyName = orderDetails.CompanyName,
                    CompanyVatNumber = orderDetails.CompanyVatNumber,
                    CountryCode = orderDetails.CountryCode,
                    City = orderDetails.City,
                    AddressLine1 = orderDetails.AddressLine1,
                    AddressLine2 = orderDetails.AddressLine2,
                    AddressLine3 = orderDetails.AddressLine3,
                    PostalCode = orderDetails.PostalCode,
                    PostalArea = orderDetails.PostalArea,
                    InvoiceTemplateName = orderDetails.InvoiceTemplateName,
                    InvoiceItems = items
                });
            }

            var result = await _batchService.OrderInvoiceBatchProcessing(order, cancellationToken);
            return new OrderInvoiceBatchCommandResult
            {
                ProcessBatchKey = result
            };
        }

        private static decimal GetValueAmount(int quantity, decimal amount, decimal? discountRate)
        {
            var @base = quantity * amount;
            var discount = discountRate != null 
                ? @base * (decimal)discountRate 
                : 0.0m;
            return @base - discount;
        }

        private static decimal GetGrossAmount(decimal amount, decimal? vatRate)
        {
            return vatRate == null 
                ? amount 
                : amount * (1 + (decimal)vatRate);
        }

        private static void CheckVoucherDateAndValueDate(DateTime? voucherDate, DateTime? valueDate)
        {
            if (voucherDate is null && valueDate is not null)
                throw new BusinessException(nameof(ErrorCodes.DATE_TYPE_MISMATCH), ErrorCodes.DATE_TYPE_MISMATCH);

            if (voucherDate is not null && valueDate is null)
                throw new BusinessException(nameof(ErrorCodes.DATE_TYPE_MISMATCH), ErrorCodes.DATE_TYPE_MISMATCH);
        }

        private static void VerifyArguments(bool isKeyValid, Guid? userId)
        {
            if (!isKeyValid)
                throw new AccessException(nameof(ErrorCodes.INVALID_PRIVATE_KEY), ErrorCodes.INVALID_PRIVATE_KEY);

            if (userId == null || userId == Guid.Empty)
                throw new BusinessException(nameof(ErrorCodes.INVALID_ASSOCIATED_USER), ErrorCodes.INVALID_ASSOCIATED_USER);
        }
    }
}