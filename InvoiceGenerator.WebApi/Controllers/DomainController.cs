namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Cqrs.Requests;
    using Backend.Cqrs.Responses;
    using MediatR;

    [ApiVersion("1.0")]
    public class DomainController : BaseController
    {
        public DomainController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCountryCodesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCountryCodesQueryResponse>> GetCountryCodes([FromQuery] string privateKey, string country) =>
            await Mediator.Send(new GetCountryCodesQueryRequest { PrivateKey = privateKey, FilterBy = country });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCurrencyCodesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetCurrencyCodesQueryResponse>> GetCurrencyCodes([FromQuery] string privateKey, string currency) =>
            await Mediator.Send(new GetCurrencyCodesQueryRequest { PrivateKey = privateKey, FilterBy = currency });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentTypesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentTypesQueryResponse>> GetPaymentTypes([FromQuery] string privateKey, string type) =>
            await Mediator.Send(new GetPaymentTypesQueryRequest { PrivateKey = privateKey, FilterBy = type });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentStatusesQueryResponse>> GetPaymentStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetPaymentStatusesQueryRequest { PrivateKey = privateKey, FilterBy = status });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetProcessingStatusesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetProcessingStatusesQueryResponse>> GetProcessingStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetProcessingStatusesQueryRequest { PrivateKey = privateKey, FilterBy = status });
    }
}