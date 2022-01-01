namespace InvoiceGenerator.Services.BatchService.Models;

using System;
using System.Diagnostics.CodeAnalysis;
using Backend.Shared.Dto.Models;

[ExcludeFromCodeCoverage]
public class OrderDetail : OrderDetailBase<InvoiceItem>
{
    public Guid UserId { get; set; }

    public Guid UserCompanyId { get; set; }

    public Guid UserBankAccountId { get; set; }

    public string InvoiceNumber { get; set; }

    public DateTime DueDate { get; set; }
}