namespace InvoiceGenerator.Backend.Shared.Dto
{
    using Shared.Models;

    public class AddInvoiceTemplateDto : RequestProperties
    {
        public string Name { get; set; }

        public byte[] Data { get; set; }

        public string DataType { get; set; }

        public string Description { get; set; }
    }
}