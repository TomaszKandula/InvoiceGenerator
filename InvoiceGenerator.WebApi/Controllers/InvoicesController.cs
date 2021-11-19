namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Responses;
    using MediatR;

    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class InvoicesController
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<OrderInvoiceBatchCommandResponse> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await _mediator.Send(InvoicesMapper.MapToOrderBatchInvoicesCommand(payload));
    }
}