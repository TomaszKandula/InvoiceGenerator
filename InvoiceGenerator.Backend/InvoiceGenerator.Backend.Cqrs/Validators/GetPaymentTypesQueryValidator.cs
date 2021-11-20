namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using Requests;
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