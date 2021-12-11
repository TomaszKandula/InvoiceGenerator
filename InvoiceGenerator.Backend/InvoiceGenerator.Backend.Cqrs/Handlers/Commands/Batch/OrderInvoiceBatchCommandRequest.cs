namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batch
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandRequest : RequestProperties, IRequest<OrderInvoiceBatchCommandResponse>
    {
        public IEnumerable<OrderDetailBase> OrderDetails { get; set; }
    }
}