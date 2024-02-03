using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

[ExcludeFromCodeCoverage]
public class GetCurrencyCodesQueryValidator : AbstractValidator<GetCurrencyCodesQuery>
{
    public GetCurrencyCodesQueryValidator()
    {
        // RuleFor(request => request.PrivateKey)
        //     .NotEmpty()
        //     .WithErrorCode(nameof(ValidationCodes.REQUIRED))
        //     .WithMessage(ValidationCodes.REQUIRED);
    }
}