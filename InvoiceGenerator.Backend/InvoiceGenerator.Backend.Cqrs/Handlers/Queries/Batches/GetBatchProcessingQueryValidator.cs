namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batches
{
    using FluentValidation;
    using Shared.Resources;

    public class GetBatchProcessingQueryValidator : AbstractValidator<GetBatchProcessingQuery>
    {
        public GetBatchProcessingQueryValidator()
        {
            RuleFor(request => request.PrivateKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
            
            RuleFor(request => request.ProcessBatchKey)
                .NotEmpty()
                .WithErrorCode(nameof(ValidationCodes.REQUIRED))
                .WithMessage(ValidationCodes.REQUIRED);
        }
    }
}