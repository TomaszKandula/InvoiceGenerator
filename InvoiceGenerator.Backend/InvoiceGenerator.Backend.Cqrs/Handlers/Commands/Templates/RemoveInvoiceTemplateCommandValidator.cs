using FluentValidation;
using InvoiceGenerator.Backend.Shared.Resources;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Templates;

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