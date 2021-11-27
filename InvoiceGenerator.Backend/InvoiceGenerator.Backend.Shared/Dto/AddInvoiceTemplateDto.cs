namespace InvoiceGenerator.Backend.Shared.Dto
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Shared.Models;
    using Attributes;

    public class AddInvoiceTemplateDto : RequestProperties
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile Data { get; set; }
    }
}