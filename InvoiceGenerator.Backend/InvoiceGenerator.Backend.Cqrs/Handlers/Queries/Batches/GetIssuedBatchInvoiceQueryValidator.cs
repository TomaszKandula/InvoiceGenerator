using FluentValidation;
using InvoiceGenerator.Backend.Shared.Resources;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches;

public class GetIssuedBatchInvoiceQueryValidator : AbstractValidator<GetIssuedBatchInvoiceQuery>
{
    public GetIssuedBatchInvoiceQueryValidator()
    {
        RuleFor(request => request.InvoiceNumber)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}