namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Backend.Cqrs.Requests;
    using Backend.Cqrs.Responses;
    using MediatR;

    public class DomainController : BaseController
    {
        public DomainController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<IEnumerable<GetCountryCodesQueryResponse>> GetCountryCodes([FromQuery] string privateKey, string country) =>
            await Mediator.Send(new GetCountryCodesQueryRequest { PrivateKey = privateKey, FilteredBy = country });

        [HttpGet]
        public async Task<IEnumerable<GetCurrencyCodesQueryResponse>> GetCurrencyCodes([FromQuery] string privateKey, string currency) =>
            await Mediator.Send(new GetCurrencyCodesQueryRequest { PrivateKey = privateKey, FilteredBy = currency });
    }
}