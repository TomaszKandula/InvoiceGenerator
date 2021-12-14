namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches
{
    using FluentValidation;
    using Shared.Resources;

    public class GetIssuedBatchInvoiceQueryValidator : AbstractValidator<GetIssuedBatchInvoiceQuery>
    {
        public GetIssuedBatchInvoiceQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.InvoiceNumber)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}