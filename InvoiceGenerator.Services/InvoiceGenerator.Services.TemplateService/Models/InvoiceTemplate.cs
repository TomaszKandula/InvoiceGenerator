namespace InvoiceGenerator.Services.TemplateService.Models;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class InvoiceTemplate
{
    public string TemplateName { get; set; }

    public InvoiceTemplateData InvoiceTemplateData { get; set; }

    public string InvoiceTemplateDescription { get; set; }
}