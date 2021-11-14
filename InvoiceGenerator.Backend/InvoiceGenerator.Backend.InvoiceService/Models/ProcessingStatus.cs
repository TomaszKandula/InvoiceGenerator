namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Domain.Enums;

    [ExcludeFromCodeCoverage]
    public class ProcessingStatus
    {
        public TimeSpan? BatchProcessingTime { get; set; }

        public InvoiceProcessingStatuses Status { get; set; }
    }
}