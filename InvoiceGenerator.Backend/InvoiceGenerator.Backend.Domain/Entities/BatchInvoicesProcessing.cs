namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class BatchInvoicesProcessing : Entity<Guid>
    {
        [Required]
        public Guid ProcessBatchKey { get; set; }

        public TimeSpan? BatchProcessingTime { get; set; }

        [Required]
        public InvoiceProcessingStatuses Status { get; set; }
        
        public BatchInvoices BatchInvoices { get; set; }
    }
}