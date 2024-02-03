using FluentValidation;
using InvoiceGenerator.Backend.Shared.Resources;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

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