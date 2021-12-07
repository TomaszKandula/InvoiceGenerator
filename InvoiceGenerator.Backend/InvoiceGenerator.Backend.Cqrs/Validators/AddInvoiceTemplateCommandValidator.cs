namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Shared.Resources;
    using Requests;

    [ExcludeFromCodeCoverage]
    public class AddInvoiceTemplateCommandValidator : AbstractValidator<AddInvoiceTemplateCommandRequest>
    {
        public AddInvoiceTemplateCommandValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(request => request.Data)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);

            RuleFor(command => command.Data)
                .Must(bytes => bytes.Length <= 4 * 1024 * 1024)
                .WithErrorCode(nameof(ValidationCodes.INVALID_FILE_SIZE))
                .WithMessage(ValidationCodes.INVALID_FILE_SIZE);

            RuleFor(request => request.Description)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}