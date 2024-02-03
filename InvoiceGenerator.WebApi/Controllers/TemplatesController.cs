using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InvoiceGenerator.Backend.Shared.Dto;
using InvoiceGenerator.Backend.Cqrs.Mappers;
using InvoiceGenerator.Services.TemplateService.Models;
using InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;
using InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;
using MediatR;

namespace InvoiceGenerator.WebApi.Controllers;

[ApiVersion("1.0")]
public class TemplatesController : BaseController
{
    public TemplatesController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InvoiceTemplateInfo>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<InvoiceTemplateInfo>> GetInvoiceTemplates([FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetInvoiceTemplatesQuery());

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    public async Task<FileContentResult> GetInvoiceTemplate(
        [FromRoute] Guid id, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetInvoiceTemplateQuery { Id = id});

    [HttpPost]
    [ProducesResponseType(typeof(AddInvoiceTemplateCommandResult), StatusCodes.Status200OK)]
    public async Task<AddInvoiceTemplateCommandResult> AddInvoiceTemplate(
        [FromForm] AddInvoiceTemplateDto payload, 
        [FromHeader(Name = HeaderName)] string privateKey)
        => await Mediator.Send(TemplatesMapper.MapToAddInvoiceTemplateCommandRequest(payload));

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    public async Task<Unit> ReplaceInvoiceTemplate(
        [FromForm] ReplaceInvoiceTemplateDto payload, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(TemplatesMapper.MapToReplaceInvoiceTemplateCommandRequest(payload));

    [HttpPost]
    [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
    public async Task<Unit> RemoveInvoiceTemplate(
        [FromBody] RemoveInvoiceTemplateDto payload, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(TemplatesMapper.MapToRemoveInvoiceTemplateCommandRequest(payload));
}