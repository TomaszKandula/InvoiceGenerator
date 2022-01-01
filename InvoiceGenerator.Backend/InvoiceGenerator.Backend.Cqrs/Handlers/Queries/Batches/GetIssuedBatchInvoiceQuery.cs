namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using MediatR;
using Microsoft.AspNetCore.Mvc;

public class GetIssuedBatchInvoiceQuery : IRequest<FileContentResult>
{
    public string InvoiceNumber { get; set; }
}