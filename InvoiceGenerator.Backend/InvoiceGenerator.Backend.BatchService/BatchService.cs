namespace InvoiceGenerator.Backend.BatchService
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

    public class BatchService : IBatchService
    {
        private readonly DatabaseContext _databaseContext;

        private readonly IDateTimeService _dateTimeService;
        
        private readonly ILoggerService _loggerService;

        public BatchService(DatabaseContext databaseContext, IDateTimeService dateTimeService, ILoggerService loggerService)
        {
            _databaseContext = databaseContext;
            _dateTimeService = dateTimeService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Place an order for invoice processing. 
        /// </summary>
        /// <param name="orderDetails">Desired invoice data.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Process Batch Key.</returns>
        public async Task<Guid> OrderInvoiceBatchProcessing(IEnumerable<OrderDetail> orderDetails, CancellationToken cancellationToken = default)
        {
            var invoices = new List<BatchInvoices>();
            var invoiceItems = new List<BatchInvoiceItems>();

            var processing = new BatchInvoicesProcessing
            {
                Id = Guid.NewGuid(),
                BatchProcessingTime = null,
                Status = ProcessingStatuses.New,
                CreatedAt = _dateTimeService.Now
            };

            foreach (var order in orderDetails)
            {
                var batchInvoiceId = Guid.NewGuid();
                invoices.Add(new BatchInvoices
                {
                    Id = batchInvoiceId,
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
                    InvoiceTemplateName = order.InvoiceTemplateName,
                    CreatedAt = _dateTimeService.Now,
                    CreatedBy = order.UserId,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id
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
                        GrossAmount = item.GrossAmount,
                        CurrencyCode = item.CurrencyCode
                    });
                }
            }

            await _databaseContext.AddAsync(processing, cancellationToken);
            await _databaseContext.AddRangeAsync(invoices, cancellationToken);
            await _databaseContext.AddRangeAsync(invoiceItems, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            var messageText1 = $"Invoice batch processing has been ordered (ProcessBatchKey: {processing.Id}).";
            var messageText2 = $"Total invoices: {invoices.Count}.";

            _loggerService.LogInformation($"{messageText1} {messageText2}.");
            return processing.Id;
        }

        /// <summary>
        /// Returns processing status of invoices to be generated.
        /// </summary>
        /// <param name="processBatchKey">Unique ID of batch process.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Processing Status object.</returns>
        /// <exception cref="BusinessException">Throws an error code INVALID_PROCESSING_BATCH_KEY.</exception>
        public async Task<ProcessingStatus> GetBatchInvoiceProcessingStatus(Guid processBatchKey, CancellationToken cancellationToken = default)
        {
            var processing = await _databaseContext.BatchInvoicesProcessing
                .AsNoTracking()
                .Where(processing => processing.Id == processBatchKey)
                .FirstOrDefaultAsync(cancellationToken);

            if (processing == null)
                throw new BusinessException(nameof(ErrorCodes.INVALID_PROCESSING_BATCH_KEY), ErrorCodes.INVALID_PROCESSING_BATCH_KEY);

            return new ProcessingStatus
            {
                Status = processing.Status,
                CreatedAt = processing.CreatedAt,
                BatchProcessingTime = processing.BatchProcessingTime
            };
        }

        /// <summary>
        /// Returns generated invoice data of given type.
        /// </summary>
        /// <param name="invoiceNumber">Binary representation of generated invoice.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Invoice (binary content).</returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<InvoiceData> GetIssuedInvoice(string invoiceNumber, CancellationToken cancellationToken = default)
        {
            var invoice = await _databaseContext.IssuedInvoices
                .AsNoTracking()
                .Where(invoices => invoices.InvoiceNumber == invoiceNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if (invoice == null)
                throw new BusinessException(nameof(ErrorCodes.INVALID_INVOICE_NUMBER), ErrorCodes.INVALID_INVOICE_NUMBER);

            return new InvoiceData
            {
                Number = invoice.InvoiceNumber,
                ContentData = invoice.InvoiceData,
                ContentType = invoice.ContentType,
                GeneratedAt = invoice.GeneratedAt
            };
        }
    }
}