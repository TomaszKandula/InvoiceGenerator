namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    public class RemoveInvoiceTemplateQueryValidator : AbstractValidator<RemoveInvoiceTemplateQueryRequest>
    {
        public RemoveInvoiceTemplateQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}