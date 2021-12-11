namespace InvoiceGenerator.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Requests;
    using Backend.Cqrs.Responses;
    using MediatR;

    [ApiVersion("1.0")]
    public class BatchController : BaseController
    {
        public BatchController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(OrderInvoiceBatchCommandResponse), StatusCodes.Status200OK)]
        public async Task<OrderInvoiceBatchCommandResponse> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(BatchMapper.MapToOrderInvoiceBatchCommandRequest(payload));

        [HttpGet]
        [ProducesResponseType(typeof(GetBatchProcessingQueryResponse), StatusCodes.Status200OK)]
        public async Task<GetBatchProcessingQueryResponse> GetBatchProcessingStatus([FromQuery] string privateKey, Guid processBatchKey) =>
            await Mediator.Send(new GetBatchProcessingQueryRequest { PrivateKey = privateKey, ProcessBatchKey = processBatchKey });

        [HttpGet]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetIssuedInvoice([FromQuery] string privateKey, string invoiceNumber) =>
            await Mediator.Send(new GetIssuedInvoiceQueryRequest { PrivateKey = privateKey, InvoiceNumber = invoiceNumber });
    }
}