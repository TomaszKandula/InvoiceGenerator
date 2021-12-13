namespace InvoiceGenerator.Backend.BatchService.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderDetail : OrderDetailBase<InvoiceItem>
    {
        public Guid UserId { get; set; }

        public Guid UserDetailId { get; set; }

        public Guid UserBankAccountId { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime DueDate { get; set; }
    }
}