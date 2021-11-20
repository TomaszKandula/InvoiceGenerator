namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Responses;
    using MediatR;

    public class InvoicesController : BaseController
    {
        public InvoicesController(IMediator mediator) :base(mediator) { }

        [HttpPost]
        public async Task<OrderInvoiceBatchCommandResponse> OrderInvoiceBatchProcessing([FromBody] OrderInvoiceBatchDto payload) 
            => await Mediator.Send(InvoicesMapper.MapToOrderBatchInvoicesCommand(payload));
    }
}