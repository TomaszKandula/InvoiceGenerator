namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Currencies;

using System.Diagnostics.CodeAnalysis;
using Shared.Resources;
using FluentValidation;

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