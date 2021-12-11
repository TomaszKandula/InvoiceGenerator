namespace InvoiceGenerator.WebApi.Controllers
{
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
        public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCodes([FromQuery] string privateKey, string country) =>
            await Mediator.Send(new GetCountryCodesQuery { PrivateKey = privateKey, FilterBy = country });
    }
}