using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;
using MediatR;

namespace InvoiceGenerator.WebApi.Controllers;

[ApiVersion("1.0")]
public class CurrenciesController : BaseController
{
    public CurrenciesController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCodeList([FromHeader(Name = HeaderName)] string privateKey) =>
        await Mediator.Send(new GetCurrencyCodesQuery { FilterBy = string.Empty });

    [HttpGet("{currency}")]
    [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResult>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCode(
        [FromRoute] string currency, 
        [FromHeader(Name = HeaderName)] string privateKey) 
        => await Mediator.Send(new GetCurrencyCodesQuery { FilterBy = currency });
}