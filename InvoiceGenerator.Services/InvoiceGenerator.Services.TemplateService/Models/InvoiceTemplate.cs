using System.Diagnostics.CodeAnalysis;

namespace InvoiceGenerator.Services.TemplateService.Models;

[ExcludeFromCodeCoverage]
public class InvoiceTemplate
{
    public string TemplateName { get; set; }

    public InvoiceTemplateData InvoiceTemplateData { get; set; }

    public string InvoiceTemplateDescription { get; set; }
}