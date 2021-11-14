namespace InvoiceGenerator.Backend.InvoiceService.Models
{
    using System;
    using Domain.Enums;

    public class ProcessingStatus
    {
        public TimeSpan? BatchProcessingTime { get; set; }

        public InvoiceProcessingStatuses Status { get; set; }
    }
}