using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries;

[ExcludeFromCodeCoverage]
public class GetCountryCodesQueryValidator : AbstractValidator<GetCountryCodesQuery>
{
    public GetCountryCodesQueryValidator()
    {
        // RuleFor(request => request.PrivateKey)
        //     .NotEmpty()
        //     .WithErrorCode(nameof(ValidationCodes.REQUIRED))
        //     .WithMessage(ValidationCodes.REQUIRED);
    }
}