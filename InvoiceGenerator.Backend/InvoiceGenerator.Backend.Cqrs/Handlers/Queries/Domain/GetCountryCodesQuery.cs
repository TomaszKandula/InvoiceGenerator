namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using MediatR;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Shared.Models;

    [ExcludeFromCodeCoverage]
    public class GetCountryCodesQuery : RequestProperties, IRequest<IEnumerable<GetCountryCodesQueryResult>>
    {
        public string FilterBy { get; set; }
    }
}