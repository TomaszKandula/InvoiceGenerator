namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Models;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchDto : RequestProperties
    {
        public Guid UserId { get; set; }

        public Guid UserDetailId { get; set; }

        public Guid UserBankAccountId { get; set; }

        public IEnumerable<OrderDetailBase<InvoiceItemBase>> OrderDetails { get; set; }
    }
}