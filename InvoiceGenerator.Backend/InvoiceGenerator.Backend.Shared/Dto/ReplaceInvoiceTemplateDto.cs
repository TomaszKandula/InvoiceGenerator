namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System;
    using Shared.Models;

    public class ReplaceInvoiceTemplateDto : RequestProperties
    {
        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public string DataType { get; set; }
    }
}