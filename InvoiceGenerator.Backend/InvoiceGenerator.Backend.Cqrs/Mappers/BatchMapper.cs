namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Dto;
    using Handlers.Commands.Batches;

    [ExcludeFromCodeCoverage]
    public static class BatchMapper
    {
        public static OrderInvoiceBatchCommand MapToOrderInvoiceBatchCommandRequest(
            OrderInvoiceBatchDto model) => new()
        {
            PrivateKey = model.PrivateKey,
            UserId = model.UserId,
            UserCompanyId = model.UserCompanyId,
            UserBankAccountId = model.UserBankAccountId,
            OrderDetails = model.OrderDetails
        };
    }
}