namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    public class GetIssuedInvoiceQueryValidator : AbstractValidator<GetIssuedInvoiceQueryRequest>
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