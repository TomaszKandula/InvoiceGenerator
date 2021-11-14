namespace InvoiceGenerator.Backend.InvoiceService
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Database;
    using Domain.Enums;
    using Domain.Entities;
    using Core.Exceptions;
    using Shared.Resources;
    using Core.Services.LoggerService;
    using Core.Services.DateTimeService;

    public class InvoiceService : IInvoiceService
    {
        private readonly DatabaseContext _databaseContext;

        private readonly IDateTimeService _dateTimeService;
        
        private readonly ILoggerService _loggerService;

        public InvoiceService(DatabaseContext databaseContext, IDateTimeService dateTimeService, ILoggerService loggerService)
        {
            _databaseContext = databaseContext;
            _dateTimeService = dateTimeService;
            _loggerService = loggerService;
        }

        public async Task<Guid> OrderInvoiceBatchProcessing(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default)
        {
            var invoices = new List<BatchInvoices>();
            var invoiceItems = new List<BatchInvoiceItems>();
            var processBatchKey = Guid.NewGuid();

            foreach (var order in orderDetails)
            {
                var batchInvoiceId = Guid.NewGuid();
                invoices.Add(new BatchInvoices
                {
                    Id = batchInvoiceId,
                    CustomerNumber = order.CustomerNumber,
                    InvoiceNumber = order.InvoiceNumber,
                    VoucherDate = order.VoucherDate,
                    ValueDate = order.ValueDate,
                    DueDate = order.DueDate,
                    PaymentTerms = order.PaymentTerms,
                    PaymentType = order.PaymentType,
                    CompanyName = order.CompanyName,
                    CompanyVatNumber = order.CompanyVatNumber,
                    CountryCode = order.CountryCode,
                    City = order.City,
                    AddressLine1 = order.AddressLine1,
                    AddressLine2 = order.AddressLine2,
                    AddressLine3 = order.AddressLine3,
                    PostalCode = order.PostalCode,
                    PostalArea = order.PostalArea,
                    ProcessBatchKey = processBatchKey
                });

                foreach (var item in order.InvoiceItems)
                {
                    invoiceItems.Add(new BatchInvoiceItems
                    {
                        Id = Guid.NewGuid(),
                        BatchInvoiceId = batchInvoiceId,
                        ItemText = item.ItemText,
                        ItemQuantity = item.ItemQuantity,
                        ItemQuantityUnit = item.ItemQuantityUnit,
                        ItemAmount = item.ItemAmount,
                        ItemDiscountRate = item.ItemDiscountRate,
                        ValueAmount = item.ValueAmount,
                        VatRate = item.VatRate,
                        GrossAmount = item.GrossAmount
                    });
                }
            }

            var processing = new BatchInvoicesProcessing
            {
                ProcessBatchKey = processBatchKey,
                BatchProcessingTime = null,
                Status = InvoiceProcessingStatuses.New,
                CreatedAt = _dateTimeService.Now
            };

            await _databaseContext.AddRangeAsync(invoices, cancellationToken);
            await _databaseContext.AddRangeAsync(invoiceItems, cancellationToken);
            await _databaseContext.AddAsync(processing, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            var messageText1 = $"Invoice batch processing has been ordered (ProcessBatchKey: {processing.ProcessBatchKey}).";
            var messageText2 = $"Total invoices: {invoices.Count}.";
            
            _loggerService.LogInformation($"{messageText1} {messageText2}.");
            return processing.ProcessBatchKey;
        }

        public async Task<ProcessingStatus> GetBatchInvoiceProcessingStatus(Guid processBatchKey, CancellationToken cancellationToken = default)
        {
            var processing = await _databaseContext.BatchInvoicesProcessing
                .AsNoTracking()
                .Where(processing => processing.ProcessBatchKey == processBatchKey)
                .FirstOrDefaultAsync(cancellationToken);

            if (processing == null)
                throw new BusinessException(nameof(ErrorCodes.INVALID_PROCESSING_BATCH_KEY), ErrorCodes.INVALID_PROCESSING_BATCH_KEY);

            return new ProcessingStatus
            {
                Status = processing.Status,
                BatchProcessingTime = processing.BatchProcessingTime
            };
        }
    }
}