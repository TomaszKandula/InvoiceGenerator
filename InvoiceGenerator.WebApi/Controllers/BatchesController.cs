namespace InvoiceGenerator.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Handlers.Queries.Batches;
    using Backend.Cqrs.Handlers.Commands.Batches;
    using MediatR;

    [ApiVersion("1.0")]
    public class BatchesController : BaseController
    {
        public BatchesController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(OrderInvoiceBatchCommandResult), StatusCodes.Status200OK)]
        public async Task<OrderInvoiceBatchCommandResult> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(BatchMapper.MapToOrderInvoiceBatchCommandRequest(payload));

        [HttpGet]
        [ProducesResponseType(typeof(GetBatchProcessingStatusQueryResult), StatusCodes.Status200OK)]
        public async Task<GetBatchProcessingStatusQueryResult> GetBatchProcessingStatus([FromQuery] string privateKey, Guid processBatchKey) =>
            await Mediator.Send(new GetBatchProcessingStatusQuery { PrivateKey = privateKey, ProcessBatchKey = processBatchKey });

        [HttpGet]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetIssuedBatchInvoice([FromQuery] string privateKey, string invoiceNumber) =>
            await Mediator.Send(new GetIssuedBatchInvoiceQuery { PrivateKey = privateKey, InvoiceNumber = invoiceNumber });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetBatchProcessingStatusListQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetBatchProcessingStatusListQueryResult>> GetBatchProcessingStatusList([FromQuery] string privateKey) =>
            await Mediator.Send(new GetBatchProcessingStatusListQuery { PrivateKey = privateKey, FilterBy = string.Empty });

        [HttpGet("{status}")]
        [ProducesResponseType(typeof(IEnumerable<GetBatchProcessingStatusListQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetBatchProcessingStatusListQueryResult>> GetBatchProcessingStatusCode([FromRoute] string status, [FromQuery] string privateKey) =>
            await Mediator.Send(new GetBatchProcessingStatusListQuery { PrivateKey = privateKey, FilterBy = status });
    }
}