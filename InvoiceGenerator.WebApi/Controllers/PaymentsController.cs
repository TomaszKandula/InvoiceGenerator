namespace InvoiceGenerator.WebApi.Controllers;

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Cqrs.Handlers.Queries.Payments;
using MediatR;

[ApiVersion("1.0")]
public class PaymentsController : BaseController
{
    public PaymentsController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentTypeListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentTypeListQueryResult>> GetPaymentTypeList([FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetPaymentTypeListQuery { FilterBy = string.Empty });

    [HttpGet("{type}")]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentTypeListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentTypeListQueryResult>> GetPaymentType([FromRoute] string type, [FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetPaymentTypeListQuery { FilterBy = type });

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentStatusListQueryResult>> GetPaymentStatusList([FromQuery] string status, [FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetPaymentStatusListQuery { FilterBy = status });

    [HttpGet("{status}")]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentStatusListQueryResult>> GetPaymentStatusCode([FromRoute] string status, [FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetPaymentStatusListQuery { FilterBy = status });
}