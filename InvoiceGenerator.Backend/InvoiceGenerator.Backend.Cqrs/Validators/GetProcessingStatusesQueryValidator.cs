namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryValidator : AbstractValidator<GetProcessingStatusesQueryRequest>
    {
        public GetProcessingStatusesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}