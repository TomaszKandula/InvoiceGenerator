namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System.Collections.Generic;
    using Models;

    public class OrderInvoiceBatchDto
    {
        public string PrivateKey { get; set; }
        
        public IEnumerable<OrderDetailBase> OrderDetails { get; set; }
    }
}