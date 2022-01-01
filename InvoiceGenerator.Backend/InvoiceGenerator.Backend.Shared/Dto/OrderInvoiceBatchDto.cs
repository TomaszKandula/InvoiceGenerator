namespace InvoiceGenerator.Backend.Shared.Dto;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Models;

[ExcludeFromCodeCoverage]
public class OrderInvoiceBatchDto
{
    public Guid UserId { get; set; }

    public Guid UserCompanyId { get; set; }

    public Guid UserBankAccountId { get; set; }

    public IEnumerable<OrderDetailBase<InvoiceItemBase>> OrderDetails { get; set; }
}