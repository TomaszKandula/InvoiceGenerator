namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandRequest : IRequest<OrderInvoiceBatchCommandResponse>
    {
        public string PrivateKey { get; set; }
        
        public IEnumerable<OrderDetailBase> OrderDetails { get; set; }
    }
}