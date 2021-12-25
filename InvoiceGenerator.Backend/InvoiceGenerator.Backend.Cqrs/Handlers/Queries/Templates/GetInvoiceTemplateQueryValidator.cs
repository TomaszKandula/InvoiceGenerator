namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

using FluentValidation;
using Shared.Resources;

public class GetInvoiceTemplateQueryValidator : AbstractValidator<GetInvoiceTemplateQuery>
{
    public GetInvoiceTemplateQueryValidator()
    {
        RuleFor(request => request.PrivateKey)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);

        RuleFor(request => request.Id)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}