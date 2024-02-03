using FluentValidation;
using InvoiceGenerator.Backend.Shared.Resources;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplateQueryValidator : AbstractValidator<GetInvoiceTemplateQuery>
{
    public GetInvoiceTemplateQueryValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}