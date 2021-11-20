namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using System.Collections.Generic;
    using MediatR;
    using Responses;
    using Shared.Models;

    public class GetCurrencyCodesQueryRequest : RequestProperties, IRequest<IEnumerable<GetCurrencyCodesQueryResponse>>
    {
        public string FilteredBy { get; set; }
    }
}