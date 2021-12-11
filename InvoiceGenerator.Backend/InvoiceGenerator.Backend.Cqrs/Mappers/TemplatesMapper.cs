#nullable enable
namespace InvoiceGenerator.Backend.Cqrs.Mappers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Http;
    using Requests;
    using Shared.Dto;

    [ExcludeFromCodeCoverage]
    public static class TemplatesMapper
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
            DataType = model.Data != null ? model.Data?.ContentType : string.Empty,
            Description = model.Description
        };

        private static byte[] GetFileContent(IFormFile? file)
        {
            if (file is null)
                return Array.Empty<byte>();

            using var fileStream = file.OpenReadStream();

            var bytes = new byte[file.Length];
            fileStream.Read(bytes, 0, (int)file.Length);

            return bytes;
        }
    }
}