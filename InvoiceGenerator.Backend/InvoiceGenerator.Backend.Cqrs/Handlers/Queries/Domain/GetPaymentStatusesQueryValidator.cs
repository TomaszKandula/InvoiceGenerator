namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Domain
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
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