namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates
{
    using FluentValidation;
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