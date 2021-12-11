namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Cqrs.Handlers.Queries.Currencies;
    using MediatR;

    [ApiVersion("1.0")]
    public class CurrenciesController : BaseController
    {
        public CurrenciesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCodeList([FromQuery] string privateKey) =>
            await Mediator.Send(new GetCurrencyCodesQuery { PrivateKey = privateKey, FilterBy = string.Empty });

        [HttpGet("{currency}")]
        [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCode([FromRoute] string currency, [FromQuery] string privateKey) =>
            await Mediator.Send(new GetCurrencyCodesQuery { PrivateKey = privateKey, FilterBy = currency });
    }
}