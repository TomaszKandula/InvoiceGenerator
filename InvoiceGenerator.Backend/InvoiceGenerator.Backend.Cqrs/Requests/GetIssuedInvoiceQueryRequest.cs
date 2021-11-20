namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Shared.Models;

    public class GetIssuedInvoiceQueryRequest : RequestProperties, IRequest<FileContentResult>
    {
        public string InvoiceNumber { get; set; }
    }
}