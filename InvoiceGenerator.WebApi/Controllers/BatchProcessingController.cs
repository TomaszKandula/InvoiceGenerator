namespace InvoiceGenerator.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Requests;
    using Backend.Cqrs.Responses;
    using MediatR;

    public class BatchProcessingController : BaseController
    {
        public BatchProcessingController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        public async Task<OrderInvoiceBatchCommandResponse> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(InvoicesMapper.MapToOrderInvoiceBatchCommandRequest(payload));

        [HttpGet]
        public async Task<GetBatchProcessingQueryResponse> GetBatchProcessingStatus([FromQuery] string privateKey, Guid processBatchKey) =>
            await Mediator.Send(new GetBatchProcessingQueryRequest { PrivateKey = privateKey, ProcessBatchKey = processBatchKey });

        [HttpGet]
        public async Task<FileContentResult> GetIssuedInvoice([FromQuery] string privateKey, string invoiceNumber) =>
            await Mediator.Send(new GetIssuedInvoiceQueryRequest { PrivateKey = privateKey, InvoiceNumber = invoiceNumber });
    }
}