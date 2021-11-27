namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Http;
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
            Data = GetFileContent(model.Data),
            DataType = model.Data.ContentType,
            Description = model.Description
        };

        private static byte[] GetFileContent(IFormFile file)
        {
            using var fileStream = file.OpenReadStream();

            var bytes = new byte[file.Length];
            fileStream.Read(bytes, 0, (int)file.Length);

            return bytes;
        }
    }
}