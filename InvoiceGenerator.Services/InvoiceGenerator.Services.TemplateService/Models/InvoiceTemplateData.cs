namespace InvoiceGenerator.Services.TemplateService.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class InvoiceTemplateData : FileResult
{
    public string Description { get; set; }
}