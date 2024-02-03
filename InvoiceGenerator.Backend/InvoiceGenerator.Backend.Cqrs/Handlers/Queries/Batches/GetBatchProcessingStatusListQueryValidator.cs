using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQueryValidator : AbstractValidator<GetBatchProcessingStatusListQuery>
{
    public GetBatchProcessingStatusListQueryValidator()
    {
        // RuleFor(request => request.PrivateKey)
        //     .NotEmpty()
        //     .WithErrorCode(nameof(ValidationCodes.REQUIRED))
        //     .WithMessage(ValidationCodes.REQUIRED);
    }
}