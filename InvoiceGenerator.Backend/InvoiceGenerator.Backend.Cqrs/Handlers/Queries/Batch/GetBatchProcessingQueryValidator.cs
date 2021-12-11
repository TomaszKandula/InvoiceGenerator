namespace InvoiceGenerator.Backend.Cqrs.Handlers.Queries.Batch
{
    using FluentValidation;
    using Shared.Resources;

    public class GetBatchProcessingQueryValidator : AbstractValidator<GetBatchProcessingQueryRequest>
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