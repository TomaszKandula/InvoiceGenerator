namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

using FluentValidation;
using Shared.Resources;

public class RemoveInvoiceTemplateCommandValidator : AbstractValidator<RemoveInvoiceTemplateCommand>
{
    public RemoveInvoiceTemplateCommandValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}