namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches
{
    using MediatR;

    public class OrderBatchProcessingCommand : IRequest<Unit> { }
}