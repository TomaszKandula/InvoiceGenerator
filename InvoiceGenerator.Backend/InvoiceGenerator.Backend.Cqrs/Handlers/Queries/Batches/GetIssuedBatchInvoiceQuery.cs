using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

public class GetIssuedBatchInvoiceQuery : IRequest<FileContentResult>
{
    public string InvoiceNumber { get; set; }
}