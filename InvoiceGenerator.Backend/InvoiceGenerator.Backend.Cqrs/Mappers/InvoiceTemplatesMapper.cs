namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Requests;
    using Shared.Dto;

    [ExcludeFromCodeCoverage]
    public static class InvoiceTemplatesMapper
    {
        public static ReplaceInvoiceTemplateCommandRequest MapToReplaceInvoiceTemplateCommandRequest(
            ReplaceInvoiceTemplateDto model) => new()
        {
            PrivateKey = model.PrivateKey,
            Id = model.Id,
            Data = model.Data,
            DataType = model.DataType
        };

        public static AddInvoiceTemplateCommandRequest MapToAddInvoiceTemplateCommandRequest(
            AddInvoiceTemplateDto model) => new()
        {
            PrivateKey = model.PrivateKey,
            Name = model.Name,
            Data = model.Data,
            DataType = model.DataType,
            Description = model.Description
        };
    }
}