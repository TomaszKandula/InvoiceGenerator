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
            TemplateId = model.TemplateId,
            TemplateData = model.TemplateData,
            TemplateDataType = model.TemplateDataType
        };

        public static AddInvoiceTemplateCommandRequest MapToAddInvoiceTemplateCommandRequest(
            AddInvoiceTemplateDto model) => new()
        {
            PrivateKey = model.PrivateKey,
            TemplateName = model.TemplateName,
            TemplateData = model.TemplateData,
            TemplateDataType = model.TemplateDataType,
            TemplateDescription = model.TemplateDescription
        };
    }
}