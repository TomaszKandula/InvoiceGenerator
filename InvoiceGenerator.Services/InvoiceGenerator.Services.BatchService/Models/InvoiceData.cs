namespace InvoiceGenerator.Services.BatchService.Models;

using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class InvoiceData : FileResult
{
    public string Number { get; set; }

    public DateTime GeneratedAt { get; set; }
}