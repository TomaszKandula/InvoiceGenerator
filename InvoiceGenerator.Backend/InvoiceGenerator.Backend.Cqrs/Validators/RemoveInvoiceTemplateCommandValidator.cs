namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    public class RemoveInvoiceTemplateCommandValidator : AbstractValidator<RemoveInvoiceTemplateCommandRequest>
    {
        public RemoveInvoiceTemplateCommandValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}