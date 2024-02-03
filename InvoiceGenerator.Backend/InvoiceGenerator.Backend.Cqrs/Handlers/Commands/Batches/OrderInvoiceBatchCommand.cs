using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Shared.Dto.Models;
using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

[ExcludeFromCodeCoverage]
public class OrderInvoiceBatchCommand : IRequest<OrderInvoiceBatchCommandResult>
{
    public Guid UserId { get; set; }

    public Guid UserCompanyId { get; set; }

    public Guid UserBankAccountId { get; set; }

    public IEnumerable<OrderDetailBase<InvoiceItemBase>> OrderDetails { get; set; }
}