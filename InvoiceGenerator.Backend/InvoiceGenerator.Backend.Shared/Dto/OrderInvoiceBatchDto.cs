namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Models;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchDto : RequestProperties
    {
        public IEnumerable<OrderDetailBase<InvoiceItemBase>> OrderDetails { get; set; }
    }
}