using System;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Shared.Dto.Models;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class OrderDetail : OrderDetailBase<InvoiceItem>
{
    public Guid UserId { get; set; }

    public Guid UserCompanyId { get; set; }

    public Guid UserBankAccountId { get; set; }

    public string InvoiceNumber { get; set; }

    public DateTime DueDate { get; set; }
}