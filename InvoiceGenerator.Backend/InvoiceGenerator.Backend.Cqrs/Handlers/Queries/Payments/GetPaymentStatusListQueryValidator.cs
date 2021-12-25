namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Shared.Resources;

[ExcludeFromCodeCoverage]
public class GetPaymentStatusListQueryValidator : AbstractValidator<GetPaymentStatusListQuery>
{
    public GetPaymentStatusListQueryValidator()
    {
        RuleFor(request => request.PrivateKey)
            .NotEmpty()
            .WithErrorCode(nameof(ValidationCodes.REQUIRED))
            .WithMessage(ValidationCodes.REQUIRED);
    }
}