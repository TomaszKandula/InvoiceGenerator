namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System;
    using Shared.Models;

    public class ReplaceInvoiceTemplateDto : RequestProperties
    {
        public Guid TemplateId { get; set; }

        public byte[] TemplateData { get; set; }

        public string TemplateDataType { get; set; }
    }
}