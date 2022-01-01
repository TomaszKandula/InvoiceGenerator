namespace InvoiceGenerator.Services.TemplateService.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class FileResult
{
    public byte[] ContentData { get; set; }

    public string ContentType { get; set; }
}