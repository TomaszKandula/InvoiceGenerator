using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.TemplateService.Models;

[ExcludeFromCodeCoverage]
public class FileResult
{
    public byte[] ContentData { get; set; }

    public string ContentType { get; set; }
}