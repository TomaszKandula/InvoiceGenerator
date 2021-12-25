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
    public async Task<IEnumerable<GetPaymentTypeListQueryResult>> GetPaymentTypeList([FromQuery] string privateKey) =>
        await Mediator.Send(new GetPaymentTypeListQuery { PrivateKey = privateKey, FilterBy = string.Empty });

    [HttpGet("{type}")]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentTypeListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentTypeListQueryResult>> GetPaymentType([FromRoute] string type, [FromQuery] string privateKey) =>
        await Mediator.Send(new GetPaymentTypeListQuery { PrivateKey = privateKey, FilterBy = type });

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentStatusListQueryResult>> GetPaymentStatusList([FromQuery] string privateKey, string status) =>
        await Mediator.Send(new GetPaymentStatusListQuery { PrivateKey = privateKey, FilterBy = status });

    [HttpGet("{status}")]
    [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusListQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetPaymentStatusListQueryResult>> GetPaymentStatusCode([FromRoute] string status, [FromQuery] string privateKey) =>
        await Mediator.Send(new GetPaymentStatusListQuery { PrivateKey = privateKey, FilterBy = status });
}