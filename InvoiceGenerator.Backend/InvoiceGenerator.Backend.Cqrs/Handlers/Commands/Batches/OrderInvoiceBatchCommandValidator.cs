using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using InvoiceGenerator.Backend.Shared.Resources;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;

[ExcludeFromCodeCoverage]
public class OrderInvoiceBatchCommandValidator : AbstractValidator<OrderInvoiceBatchCommand>
{
    public OrderInvoiceBatchCommandValidator()
    {
        RuleFor(request => request.UserId)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);

        RuleFor(request => request.UserCompanyId)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);

        RuleFor(request => request.UserBankAccountId)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}