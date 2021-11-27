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
            await Mediator.Send(new GetCountryCodesQueryRequest { PrivateKey = privateKey, FilterBy = country });

        [HttpGet]
        public async Task<IEnumerable<GetCurrencyCodesQueryResponse>> GetCurrencyCodes([FromQuery] string privateKey, string currency) =>
            await Mediator.Send(new GetCurrencyCodesQueryRequest { PrivateKey = privateKey, FilterBy = currency });

        [HttpGet]
        public async Task<IEnumerable<GetPaymentTypesQueryResponse>> GetPaymentTypes([FromQuery] string privateKey, string type) =>
            await Mediator.Send(new GetPaymentTypesQueryRequest { PrivateKey = privateKey, FilterBy = type });

        [HttpGet]
        public async Task<IEnumerable<GetPaymentStatusesQueryResponse>> GetPaymentStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetPaymentStatusesQueryRequest { PrivateKey = privateKey, FilterBy = status });

        [HttpGet]
        public async Task<IEnumerable<GetProcessingStatusesQueryResponse>> GetProcessingStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetProcessingStatusesQueryRequest { PrivateKey = privateKey, FilterBy = status });
    }
}