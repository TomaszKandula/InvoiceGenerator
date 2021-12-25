namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Shared.Resources;

[ExcludeFromCodeCoverage]
public class GetBatchProcessingStatusListQueryValidator : AbstractValidator<GetBatchProcessingStatusListQuery>
{
    public GetBatchProcessingStatusListQueryValidator()
    {
        RuleFor(request => request.PrivateKey)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}