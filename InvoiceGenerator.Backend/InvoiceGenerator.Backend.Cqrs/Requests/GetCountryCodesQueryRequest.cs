namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using Responses;
    using Shared.Models;

    public class GetCountryCodesQueryRequest : RequestProperties, IRequest<IEnumerable<GetCountryCodesQueryResponse>>
    {
        public string FilteredBy { get; set; }
    }
}