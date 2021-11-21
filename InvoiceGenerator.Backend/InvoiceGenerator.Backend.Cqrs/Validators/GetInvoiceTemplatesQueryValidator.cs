namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using FluentValidation;
    using Shared.Resources;
    using Requests;

    public class GetInvoiceTemplatesQueryValidator : AbstractValidator<GetInvoiceTemplatesQueryRequest>
    {
        public GetInvoiceTemplatesQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}