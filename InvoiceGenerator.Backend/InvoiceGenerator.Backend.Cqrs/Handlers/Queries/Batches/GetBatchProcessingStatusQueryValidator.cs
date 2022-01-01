namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using FluentValidation;
using Shared.Resources;

public class GetBatchProcessingStatusQueryValidator : AbstractValidator<GetBatchProcessingStatusQuery>
{
    public GetBatchProcessingStatusQueryValidator()
    {
        RuleFor(request => request.ProcessBatchKey)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}