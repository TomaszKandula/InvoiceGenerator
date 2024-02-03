using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Shared.Dto.Models;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class InvoiceItem : InvoiceItemBase
{
    public decimal ValueAmount { get; set; }

    public decimal GrossAmount { get; set; }
}