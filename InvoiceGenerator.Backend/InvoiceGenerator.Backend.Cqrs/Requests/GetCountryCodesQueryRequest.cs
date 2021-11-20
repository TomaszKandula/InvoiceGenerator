namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetCountryCodesQueryRequest : RequestProperties, IRequest<IEnumerable<GetCountryCodesQueryResponse>>
    {
        public string FilteredBy { get; set; }
    }
}