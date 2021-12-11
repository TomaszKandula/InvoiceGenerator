namespace InvoiceGenerator.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Backend.Cqrs.Handlers.Queries.Payments;
    using MediatR;

    [ApiVersion("1.0")]
    public class PaymentsController : BaseController
    {
        public PaymentsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentTypesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentTypesQueryResult>> GetPaymentTypes([FromQuery] string privateKey, string type) =>
            await Mediator.Send(new GetPaymentTypesQuery { PrivateKey = privateKey, FilterBy = type });

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPaymentStatusesQueryResult>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetPaymentStatusesQueryResult>> GetPaymentStatuses([FromQuery] string privateKey, string status) =>
            await Mediator.Send(new GetPaymentStatusesQuery { PrivateKey = privateKey, FilterBy = status });
    }
}