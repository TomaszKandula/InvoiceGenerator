namespace InvoiceGenerator.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Shared.Dto;
    using Backend.Cqrs.Mappers;
    using Backend.Cqrs.Requests;
    using Backend.Cqrs.Responses;
    using Backend.TemplateService.Models;
    using MediatR;

    [ApiVersion("1.0")]
    public class TemplatesController : BaseController
    {
        public TemplatesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoiceTemplateInfo>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<InvoiceTemplateInfo>> GetInvoiceTemplates([FromQuery] string privateKey) 
            => await Mediator.Send(new GetInvoiceTemplatesQueryRequest { PrivateKey = privateKey });

        [HttpGet]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<FileContentResult> GetInvoiceTemplate([FromQuery] string privateKey, Guid templateId) 
            => await Mediator.Send(new GetInvoiceTemplateQueryRequest { PrivateKey = privateKey, Id = templateId});

        [HttpPost]
        [ProducesResponseType(typeof(AddInvoiceTemplateCommandResponse), StatusCodes.Status200OK)]
        public async Task<AddInvoiceTemplateCommandResponse> AddInvoiceTemplate([FromForm] AddInvoiceTemplateDto payload)
            => await Mediator.Send(InvoiceTemplatesMapper.MapToAddInvoiceTemplateCommandRequest(payload));

        [HttpPost]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<Unit> ReplaceInvoiceTemplate([FromForm] ReplaceInvoiceTemplateDto payload) 
            => await Mediator.Send(InvoiceTemplatesMapper.MapToReplaceInvoiceTemplateCommandRequest(payload));

        [HttpPost]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        public async Task<Unit> RemoveInvoiceTemplate([FromQuery] string privateKey, Guid templateId) 
            => await Mediator.Send(new RemoveInvoiceTemplateQueryRequest { PrivateKey = privateKey, Id = templateId });
    }
}