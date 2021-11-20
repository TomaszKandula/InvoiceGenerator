namespace InvoiceGenerator.Backend.Cqrs.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Shared.Resources;
    using Requests;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandValidator : AbstractValidator<OrderInvoiceBatchCommandRequest>
    {
        public OrderInvoiceBatchCommandValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}