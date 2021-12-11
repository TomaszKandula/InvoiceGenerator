namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Requests;
    using Shared.Dto;

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