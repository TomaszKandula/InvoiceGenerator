namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using FluentValidation;
    using Shared.Resources;

    public class GetIssuedInvoiceQueryValidator : AbstractValidator<GetIssuedInvoiceQuery>
    {
        public GetIssuedInvoiceQueryValidator()
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