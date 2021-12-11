namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Resources;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQueryValidator : AbstractValidator<GetPaymentTypesQuery>
    {
        public GetPaymentTypesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}