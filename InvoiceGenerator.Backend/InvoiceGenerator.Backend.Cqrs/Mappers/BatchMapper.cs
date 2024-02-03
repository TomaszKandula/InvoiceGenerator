using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Cqrs.Handlers.Commands.Batches;
using InvoiceGenerator.Backend.Shared.Dto;

namespace InvoiceGenerator.Backend.Cqrs.Mappers;

[ExcludeFromCodeCoverage]
public static class BatchMapper
{
    public static OrderInvoiceBatchCommand MapToOrderInvoiceBatchCommandRequest(
        OrderInvoiceBatchDto model) => new()
    {
        UserId = model.UserId,
        UserCompanyId = model.UserCompanyId,
        UserBankAccountId = model.UserBankAccountId,
        OrderDetails = model.OrderDetails
    };
}