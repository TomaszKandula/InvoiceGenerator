using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InvoiceGenerator.Backend.Shared.Dto;
using InvoiceGenerator.Backend.Cqrs.Mappers;
using InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;
using InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;
using MediatR;

namespace InvoiceGenerator.WebApi.Controllers;

[ApiVersion("1.0")]
public class BatchesController : BaseController
{
    public BatchesController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    [ProducesResponseType(typeof(OrderInvoiceBatchCommandResult), StatusCodes.Status200OK)]
    public async Task<OrderInvoiceBatchCommandResult> OrderInvoiceBatch(
        [FromBody] OrderInvoiceBatchDto payload, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(BatchMapper.MapToOrderInvoiceBatchCommandRequest(payload));

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    public async Task<Unit> OrderBatchProcessing([FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new OrderBatchProcessingCommand());

    [HttpGet]
    [ProducesResponseType(typeof(GetBatchProcessingStatusQueryResult), StatusCodes.Status200OK)]
    public async Task<GetBatchProcessingStatusQueryResult> GetBatchProcessingStatus(
        [FromQuery] Guid processBatchKey, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetBatchProcessingStatusQuery { ProcessBatchKey = processBatchKey });

    [HttpGet]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    public async Task<FileContentResult> GetIssuedBatchInvoice(
        [FromQuery] string invoiceNumber, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetIssuedBatchInvoiceQuery { InvoiceNumber = invoiceNumber });

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetBatchProcessingStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetBatchProcessingStatusListQueryResult>> GetBatchProcessingStatusList(
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetBatchProcessingStatusListQuery { FilterBy = string.Empty });

    [HttpGet("{status}")]
    [ProducesResponseType(typeof(IEnumerable<GetBatchProcessingStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetBatchProcessingStatusListQueryResult>> GetBatchProcessingStatusCode(
        [FromRoute] string status, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetBatchProcessingStatusListQuery { FilterBy = status });
}