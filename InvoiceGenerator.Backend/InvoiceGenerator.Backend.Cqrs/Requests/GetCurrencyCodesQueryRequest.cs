namespace InvoiceGenerator.Backend.Cqrs.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Responses;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetCurrencyCodesQueryRequest : RequestProperties, IRequest<IEnumerable<GetCurrencyCodesQueryResponse>>
    {
        public string FilteredBy { get; set; }
    }
}