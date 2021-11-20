namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using Requests;
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