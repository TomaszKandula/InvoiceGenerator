namespace InvoiceGenerator.Services.BatchService.Models;

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using Backend.Domain.Entities;

[ExcludeFromCodeCoverage]
public class ProcessingError
{
    public string Error { get; set; }

    public string InnerError { get; set; }

    public string InvoiceNumber { get; set; }

    public Stopwatch Timer { get; set; }

    public BatchInvoicesProcessing ProcessingObject { get; set; }
}