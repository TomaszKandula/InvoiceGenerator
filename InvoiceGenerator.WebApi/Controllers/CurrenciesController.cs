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
        public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCodes([FromQuery] string privateKey, string currency) =>
            await Mediator.Send(new GetCurrencyCodesQuery { PrivateKey = privateKey, FilterBy = currency });
    }
}