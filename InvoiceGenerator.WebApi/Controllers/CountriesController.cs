using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;
using MediatR;

namespace InvoiceGenerator.WebApi.Controllers;

[ApiVersion("1.0")]
public class CountriesController : BaseController
{
    public CountriesController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCodeList([FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetCountryCodesQuery { FilterBy = string.Empty });

    [HttpGet("{country}")]
    [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCode(
        [FromRoute] string country, 
        [FromHeader(Name = HeaderName)] string privateKey)
        => await Mediator.Send(new GetCountryCodesQuery { FilterBy = country });
}