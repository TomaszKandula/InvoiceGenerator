namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Cqrs.Handlers.Queries.Batch;
    using Backend.Cqrs.Handlers.Queries.Domain;
    using MediatR;

    [ApiVersion("1.0")]
    public class DomainController : BaseController
    {
        public DomainController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCountryCodesQueryResult>> GetCountryCodes([FromQuery] string privateKey, string country) =>
            await Mediator.Send(new GetCountryCodesQuery { PrivateKey = privateKey, FilterBy = country });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCurrencyCodesQueryResult>> GetCurrencyCodes([FromQuery] string privateKey, string currency) =>
            await Mediator.Send(new GetCurrencyCodesQuery { PrivateKey = privateKey, FilterBy = currency });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentTypesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentTypesQueryResult>> GetPaymentTypes([FromQuery] string privateKey, string type) =>
            await Mediator.Send(new GetPaymentTypesQuery { PrivateKey = privateKey, FilterBy = type });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentStatusesQueryResult>> GetPaymentStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetPaymentStatusesQuery { PrivateKey = privateKey, FilterBy = status });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetProcessingStatusesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetProcessingStatusesQueryResult>> GetProcessingStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetProcessingStatusesQuery { PrivateKey = privateKey, FilterBy = status });
    }
}