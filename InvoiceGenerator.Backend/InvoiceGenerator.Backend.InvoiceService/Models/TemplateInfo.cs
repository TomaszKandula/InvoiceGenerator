namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TemplateInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}