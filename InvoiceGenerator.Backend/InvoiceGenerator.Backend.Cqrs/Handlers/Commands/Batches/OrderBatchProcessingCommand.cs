using MediatR;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

public class OrderBatchProcessingCommand : IRequest<Unit> { }