#nullable enable
namespace InvoiceGenerator.Backend.Cqrs.Mappers;

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Shared.Dto;
using Handlers.Commands.Templates;

[ExcludeFromCodeCoverage]
public static class TemplatesMapper
{
    public static ReplaceInvoiceTemplateCommand MapToReplaceInvoiceTemplateCommandRequest(
        ReplaceInvoiceTemplateDto model) => new()
    {
        Id = model.Id,
        Data = GetFileContent(model.Data),
        DataType = model.Data != null ? model.Data?.ContentType : string.Empty,
        Description = model.Description
    };

    public static AddInvoiceTemplateCommand MapToAddInvoiceTemplateCommandRequest(
        AddInvoiceTemplateDto model) => new()
    {
        Name = model.Name,
        Data = GetFileContent(model.Data),
        DataType = model.Data != null ? model.Data?.ContentType : string.Empty,
        Description = model.Description
    };

    public static RemoveInvoiceTemplateCommand MapToRemoveInvoiceTemplateCommandRequest(
        RemoveInvoiceTemplateDto model) => new()
    {
        Id = model.Id
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