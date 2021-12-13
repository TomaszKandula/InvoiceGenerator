namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;
    using Shared.Dto.Models;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommand : RequestProperties, IRequest<OrderInvoiceBatchCommandResult>
    {
        public Guid UserId { get; set; }

        public Guid UserDetailId { get; set; }

        public Guid UserBankAccountId { get; set; }

        public IEnumerable<OrderDetailBase<InvoiceItemBase>> OrderDetails { get; set; }
    }
}