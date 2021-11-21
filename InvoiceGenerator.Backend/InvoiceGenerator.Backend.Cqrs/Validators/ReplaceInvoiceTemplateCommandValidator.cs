namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using FluentValidation;
    using Requests;
    using Shared.Resources;

    public class ReplaceInvoiceTemplateCommandValidator : AbstractValidator<ReplaceInvoiceTemplateCommandRequest>
    {
        public ReplaceInvoiceTemplateCommandValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.Id)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.Data)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.DataType)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}