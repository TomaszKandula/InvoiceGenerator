namespace InvoiceGenerator.Backend.Shared.Dto
{
    using Shared.Models;

    public class AddInvoiceTemplateDto : RequestProperties
    {
        public string TemplateName { get; set; }

        public byte[] TemplateData { get; set; }

        public string TemplateDataType { get; set; }

        public string TemplateDescription { get; set; }
    }
}