using System;
using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class InvoiceData : FileResult
{
    public string Number { get; set; }

    public DateTime GeneratedAt { get; set; }
}