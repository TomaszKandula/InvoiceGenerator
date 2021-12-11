namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Resources;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class GetCurrencyCodesQueryValidator : AbstractValidator<GetCurrencyCodesQueryRequest>
    {
        public GetCurrencyCodesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}