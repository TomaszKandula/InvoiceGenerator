using FluentValidation;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates;

public class GetInvoiceTemplatesQueryValidator : AbstractValidator<GetInvoiceTemplatesQuery>
{
    public GetInvoiceTemplatesQueryValidator()
    {
        // RuleFor(request => request.PrivateKey)
        //     .NotEmpty()
        //     .WithErrorCode(nameof(ValidationCodes.REQUIRED))
        //     .WithMessage(ValidationCodes.REQUIRED);
    }
}