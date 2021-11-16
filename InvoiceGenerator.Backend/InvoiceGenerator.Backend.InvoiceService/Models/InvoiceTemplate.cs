namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class InvoiceTemplate
    {
        public string TemplateName { get; set; }

        public TemplateData TemplateData { get; set; }

        public string ShortDescription { get; set; }
    }
}