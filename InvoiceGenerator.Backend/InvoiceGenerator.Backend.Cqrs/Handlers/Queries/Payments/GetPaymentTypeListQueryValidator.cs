using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Payments;

[ExcludeFromCodeCoverage]
public class GetPaymentTypeListQueryValidator : AbstractValidator<GetPaymentTypeListQuery>
{
    public GetPaymentTypeListQueryValidator()
    {
        // RuleFor(request => request.PrivateKey)
        //     .NotEmpty()
        //     .WithErrorCode(nameof(ValidationCodes.REQUIRED))
        //     .WithMessage(ValidationCodes.REQUIRED);
    }
}