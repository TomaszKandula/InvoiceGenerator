using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.TemplateService.Models;

[ExcludeFromCodeCoverage]
public class InvoiceTemplateData : FileResult
{
    public string Description { get; set; }
}