namespace InvoiceGenerator.WebApi.Controllers;

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Cqrs.Handlers.Queries.Countries;
using MediatR;

[ApiVersion("1.0")]
public class CountriesController : BaseController
{
    public CountriesController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCodeList([FromQuery] string privateKey) =>
        await Mediator.Send(new GetCountryCodesQuery { PrivateKey = privateKey, FilterBy = string.Empty });

    [HttpGet("{country}")]
    [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCode([FromRoute] string country, [FromQuery] string privateKey) =>
        await Mediator.Send(new GetCountryCodesQuery { PrivateKey = privateKey, FilterBy = country });
}