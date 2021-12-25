namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

public class GetIssuedBatchInvoiceQuery : RequestProperties, IRequest<FileContentResult>
{
    public string InvoiceNumber { get; set; }
}