namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    [ExcludeFromCodeCoverage]
    public class GetPaymentStatusesQueryValidator : AbstractValidator<GetPaymentStatusesQueryRequest>
    {
        public GetPaymentStatusesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}