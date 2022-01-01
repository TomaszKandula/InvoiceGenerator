namespace InvoiceGenerator.Services.VatService.Models;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Backend.Domain.Entities;

[ExcludeFromCodeCoverage]
public class VatValidationRequest
{
    public string VatNumber { get; set; }

    public IEnumerable<VatNumberPatterns> VatNumberPatterns { get; set; }

    public PolishVatNumberOptions Options { get; set; }

    public VatValidationRequest(string vatNumber, IEnumerable<VatNumberPatterns> vatNumberPatterns, PolishVatNumberOptions options = default)
    {
        VatNumber = vatNumber;
        VatNumberPatterns = vatNumberPatterns;
        Options = options;
    }
}