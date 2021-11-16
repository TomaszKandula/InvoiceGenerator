namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class InvoiceData
    {
        public string Number { get; set; }

        public byte[] ContentData { get; set; }

        public string ContentType { get; set; }

        public DateTime GeneratedAt { get; set; }
    }
}