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

    public class InvoicesController : BaseController
    {
        public InvoicesController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        public async Task<OrderInvoiceBatchCommandResponse> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(InvoicesMapper.MapToOrderBatchInvoicesCommand(payload));
        
        [HttpGet]
        public async Task<GetBatchProcessingStatusQueryResponse> GetBatchProcessingStatus([FromQuery] string privateKey, Guid processBatchKey) =>
            await Mediator.Send(new GetBatchProcessingStatusQueryRequest { PrivateKey = privateKey, ProcessBatchKey = processBatchKey });
    }
}