namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Countries
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Shared.Resources;

    [ExcludeFromCodeCoverage]
    public class GetCountryCodesQueryValidator : AbstractValidator<GetCountryCodesQuery>
    {
        public GetCountryCodesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}