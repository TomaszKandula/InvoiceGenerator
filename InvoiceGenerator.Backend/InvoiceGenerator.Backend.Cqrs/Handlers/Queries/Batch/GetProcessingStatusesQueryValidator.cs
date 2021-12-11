namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Shared.Resources;

    [ExcludeFromCodeCoverage]
    public class GetProcessingStatusesQueryValidator : AbstractValidator<GetProcessingStatusesQuery>
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