namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Models;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandRequest : RequestProperties, IRequest<OrderInvoiceBatchCommandResponse>
    {
        public IEnumerable<OrderDetailBase> OrderDetails { get; set; }
    }
}