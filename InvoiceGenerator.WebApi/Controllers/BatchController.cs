namespace InvoiceGenerator.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Handlers.Queries.Batch;
    using Backend.Cqrs.Handlers.Commands.Batch;
    using MediatR;

    [ApiVersion("1.0")]
    public class BatchController : BaseController
    {
        public BatchController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(OrderInvoiceBatchCommandResult), StatusCodes.Status200OK)]
        public async Task<OrderInvoiceBatchCommandResult> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(BatchMapper.MapToOrderInvoiceBatchCommandRequest(payload));

        [HttpGet]
        [ProducesResponseType(typeof(GetBatchProcessingQueryResult), StatusCodes.Status200OK)]
        public async Task<GetBatchProcessingQueryResult> GetBatchProcessingStatus([FromQuery] string privateKey, Guid processBatchKey) =>
            await Mediator.Send(new GetBatchProcessingQuery { PrivateKey = privateKey, ProcessBatchKey = processBatchKey });

        [HttpGet]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetIssuedInvoice([FromQuery] string privateKey, string invoiceNumber) =>
            await Mediator.Send(new GetIssuedInvoiceQuery { PrivateKey = privateKey, InvoiceNumber = invoiceNumber });
    }
}