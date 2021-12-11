namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Models;

    public class GetIssuedInvoiceQuery : RequestProperties, IRequest<FileContentResult>
    {
        public string InvoiceNumber { get; set; }
    }
}