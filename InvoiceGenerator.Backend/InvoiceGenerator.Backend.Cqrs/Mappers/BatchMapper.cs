namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Shared.Dto;
    using Handlers.Commands.Batch;

    [ExcludeFromCodeCoverage]
    public static class BatchMapper
    {
        public static OrderInvoiceBatchCommandRequest MapToOrderInvoiceBatchCommandRequest(
            OrderInvoiceBatchDto model) => new()
        {
            PrivateKey = model.PrivateKey,
            OrderDetails = model.OrderDetails
        };
    }
}