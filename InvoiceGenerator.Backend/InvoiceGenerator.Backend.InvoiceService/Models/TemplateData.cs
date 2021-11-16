namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TemplateData
    {
        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }
    }
}