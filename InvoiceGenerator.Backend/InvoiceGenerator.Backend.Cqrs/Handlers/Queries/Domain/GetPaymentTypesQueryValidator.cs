namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Resources;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class GetPaymentTypesQueryValidator : AbstractValidator<GetPaymentTypesQueryRequest>
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