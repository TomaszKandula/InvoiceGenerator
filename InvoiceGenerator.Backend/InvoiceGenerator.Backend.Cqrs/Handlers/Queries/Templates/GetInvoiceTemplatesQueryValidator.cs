namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Templates
{
    using FluentValidation;
    using Shared.Resources;

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