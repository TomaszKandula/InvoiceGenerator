namespace InvoiceGenerator.Backend.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    [ExcludeFromCodeCoverage]
    public class BatchInvoicesProcessing : Entity<Guid>
    {
        public TimeSpan? BatchProcessingTime { get; set; }

        [Required]
        public ProcessingStatuses Status { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        public ICollection<BatchInvoices> BatchInvoices { get; set; } = new HashSet<BatchInvoices>();
    }
}