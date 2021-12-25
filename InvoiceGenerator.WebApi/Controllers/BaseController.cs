namespace InvoiceGenerator.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Backend.Core.Models;

[ApiController]
[AllowAnonymous]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ProducesResponseType(typeof(ApplicationError), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ApplicationError), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(ApplicationError), StatusCodes.Status403Forbidden)]
[ProducesResponseType(typeof(ApplicationError), StatusCodes.Status422UnprocessableEntity)]
[ProducesResponseType(typeof(ApplicationError), StatusCodes.Status500InternalServerError)]
public class BaseController : ControllerBase
{
    protected readonly IMediator Mediator;

    public BaseController(IMediator mediator) => Mediator = mediator;
}