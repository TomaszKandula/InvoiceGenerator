namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches
{
    using System.Diagnostics.CodeAnalysis;
    using FluentValidation;
    using Shared.Resources;

    [ExcludeFromCodeCoverage]
    public class OrderInvoiceBatchCommandValidator : AbstractValidator<OrderInvoiceBatchCommand>
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