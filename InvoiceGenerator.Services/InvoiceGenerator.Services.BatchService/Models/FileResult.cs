using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.BatchService.Models;

[ExcludeFromCodeCoverage]
public class FileResult
{
    public byte[] ContentData { get; set; }

    public string ContentType { get; set; }
}