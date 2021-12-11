namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Resources;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypeListQueryValidator : AbstractValidator<GetPaymentTypeListQuery>
    {
        public GetPaymentTypeListQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}