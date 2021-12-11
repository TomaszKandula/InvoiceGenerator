namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batch
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommand : RequestProperties, IRequest<OrderInvoiceBatchCommandResult>
    {
        public IEnumerable<OrderDetailBase> OrderDetails { get; set; }
    }
}