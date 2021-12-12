namespace InvoiceGenerator.Backend.BatchService
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Threading;
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
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
                    VoucherDate = order.VoucherDate ?? DateTime.Now,
                    ValueDate = order.ValueDate ?? DateTime.Now,
                    DueDate = order.DueDate,
                    PaymentTerms = order.PaymentTerms,
                    PaymentType = order.PaymentType,
                    CustomerName = order.CompanyName,
                    CustomerVatNumber = order.CompanyVatNumber,
                    CountryCode = order.CountryCode,
                    City = order.City,
                    StreetAddress = order.StreetAddress,
                    PostalCode = order.PostalCode,
                    PostalArea = order.PostalArea,
                    InvoiceTemplateName = order.InvoiceTemplateName,
                    CreatedAt = _dateTimeService.Now,
                    CreatedBy = order.UserId,
                    ModifiedAt = null,
                    ModifiedBy = null,
                    ProcessBatchKey = processing.Id,
                    UserId = order.UserId,
                    UserDetailId = order.UserDetailId,
                    UserBankDataId = order.UserBankDataId
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
        /// Processes all outstanding invoices that have status 'new'.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task ProcessOutstandingInvoices(CancellationToken cancellationToken = default)
        {
            var processingList = await _databaseContext.BatchInvoicesProcessing
                .AsNoTracking()
                .Where(processing => processing.Status == ProcessingStatuses.New)
                .Select(processing => processing.Id)
                .ToListAsync(cancellationToken);

            if (!processingList.Any())
            {
                _loggerService.LogInformation("No new invoices to process.");
                return;
            }

            var invoicesIds = new HashSet<Guid>(processingList);
            var invoices = await _databaseContext.BatchInvoices
                .AsNoTracking()
                .Where(batchInvoices => invoicesIds.Contains(batchInvoices.ProcessBatchKey))
                .ToListAsync(cancellationToken);

            var invoiceItemsIds = new HashSet<Guid>(invoices.Select(batchInvoices => batchInvoices.Id));
            var invoiceItemsList = await _databaseContext.BatchInvoiceItems
                .AsNoTracking()
                .Where(batchInvoiceItems => invoiceItemsIds.Contains(batchInvoiceItems.BatchInvoiceId))
                .ToListAsync(cancellationToken);

            var templateNames = invoices
                .Select(batchInvoices => batchInvoices.InvoiceTemplateName)
                .ToList();

            var invoiceTemplates = await _databaseContext.InvoiceTemplates
                .AsNoTracking()
                .Where(templates => templateNames.Contains(templates.Name))
                .Where(templates => !templates.IsDeleted)
                .ToListAsync(cancellationToken);

            var userIds = new HashSet<Guid>(invoices.Select(batchInvoices => batchInvoices.UserId));
            var userEmailAddressList = await _databaseContext.Users
                .AsNoTracking()
                .Where(users => userIds.Contains(users.Id))
                .ToListAsync(cancellationToken);

            var userDetailsList = await _databaseContext.UserDetails
                .AsNoTracking()
                .Where(details => userIds.Contains(details.UserId))
                .ToListAsync(cancellationToken);

            var userBankDataList = await _databaseContext.UserBankData
                .AsNoTracking()
                .Where(bankData => userIds.Contains(bankData.UserId))
                .ToListAsync(cancellationToken);

            var issuedInvoices = new List<IssuedInvoices>();
            
            foreach (var invoice in invoices)
            {
                var templateData = invoiceTemplates
                    .Where(templates => templates.Name == invoice.InvoiceTemplateName)
                    .Select(templates => templates.Data)
                    .SingleOrDefault();

                if (templateData is null)
                {
                    _loggerService.LogWarning($"Cannot process invoice (PBK: {invoice.BatchInvoicesProcessing}). Missing invoice template.");
                }
                else
                {
                    _loggerService.LogInformation($"Start processing invoice number: {invoice.InvoiceNumber}");

                    var processedInvoiceBatch = await _databaseContext.BatchInvoicesProcessing
                        .Where(processing => processing.Id == invoice.ProcessBatchKey)
                        .SingleOrDefaultAsync(cancellationToken);

                    processedInvoiceBatch.Status = ProcessingStatuses.InvoiceGeneratingStarted;
                    await _databaseContext.SaveChangesAsync(cancellationToken);
                    
                    var timer = new Stopwatch();
                    timer.Start();
                    
                    var userEmailAddress = userEmailAddressList
                        .Where(users => users.Id == invoice.UserId)
                        .Select(users => users.EmailAddress)
                        .FirstOrDefault();

                    var userDetails = userDetailsList
                        .FirstOrDefault(details => details.UserId == invoice.UserDetailId);

                    var userBankData = userBankDataList
                        .FirstOrDefault(bankData => bankData.UserId == invoice.UserBankDataId);

                    var template = Encoding.Default.GetString(templateData);
                    var userFullAddress = $"{userDetails?.StreetAddress} {userDetails?.PostalCode} {userDetails?.City}";
                    var newInvoice = template
                        .Replace("{{F1}}", userDetails?.CompanyName)
                        .Replace("{{F2}}", userFullAddress)
                        .Replace("{{F3}}", userDetails?.VatNumber)
                        .Replace("{{F4}}", userEmailAddress)
                        .Replace("{{F5}}", "Missing User Phone Number")
                        .Replace("{{F6}}", invoice.InvoiceNumber)
                        .Replace("{{F7}}", invoice.ValueDate.ToString(CultureInfo.InvariantCulture))
                        .Replace("{{F8}}", invoice.DueDate.ToString(CultureInfo.InvariantCulture))
                        .Replace("{{F9}}", $"{invoice.PaymentTerms} days")
                        .Replace("{{F10}}", "Missing Invoice Currency")
                        .Replace("{{F11}}", invoice.CustomerName)
                        .Replace("{{F12}}", invoice.CustomerVatNumber)
                        .Replace("{{F13}}", invoice.StreetAddress)
                        .Replace("{{F14}}", "Missing Customer Phone Number")
                        .Replace("{{F25}}", userBankData?.BankName)
                        .Replace("{{F26}}", userBankData?.SwiftNumber)
                        .Replace("{{F27}}", userBankData?.AccountNumber)
                        .Replace("{{F28}}", "Payment Status EXT")
                        .Replace("{{F29}}", invoice.PaymentType.ToString());

                    var rowTemplate = Regex.Match(template, @"(?<=<row-template>)((.|\n)*)(?=<\/row-template>)");
                    var invoiceItems = string.Empty;
                    var totalAmount = 0.0m;

                    foreach (var item in invoiceItemsList)
                    {
                        totalAmount += item.GrossAmount;
                        invoiceItems += rowTemplate.Value
                            .Replace("{{F15}}", item.ItemText)
                            .Replace("{{F16}}", item.ItemQuantity.ToString())
                            .Replace("{{F17}}", item.ItemQuantityUnit)
                            .Replace("{{F18}}", item.ItemAmount.ToString(CultureInfo.InvariantCulture))
                            .Replace("{{F19}}", item.ItemDiscountRate.ToString())
                            .Replace("{{F20}}", item.ValueAmount.ToString(CultureInfo.InvariantCulture))
                            .Replace("{{F21}}", item.VatRate.ToString())
                            .Replace("{{F22}}", item.GrossAmount.ToString(CultureInfo.InvariantCulture));
                    }

                    newInvoice = newInvoice
                        .Replace(rowTemplate.Value, invoiceItems)
                        .Replace("{{F23}}", totalAmount.ToString(CultureInfo.InvariantCulture));

                    var issuedInvoice = new IssuedInvoices
                    {
                        UserId = invoice.UserId,
                        InvoiceNumber = invoice.InvoiceNumber,
                        InvoiceData = Encoding.Default.GetBytes(newInvoice),
                        ContentType = "text/html",
                        GeneratedAt = _dateTimeService.Now
                    };

                    issuedInvoices.Add(issuedInvoice);
                    timer.Stop();
                    
                    processedInvoiceBatch.Status = ProcessingStatuses.InvoiceGeneratingFinished;
                    processedInvoiceBatch.BatchProcessingTime = timer.Elapsed;
                    
                    await _databaseContext.SaveChangesAsync(cancellationToken);
                }
            }

            if (issuedInvoices.Any())
            {
                await _databaseContext.IssuedInvoices.AddRangeAsync(issuedInvoices, cancellationToken);
                await _databaseContext.SaveChangesAsync(cancellationToken);
            }
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