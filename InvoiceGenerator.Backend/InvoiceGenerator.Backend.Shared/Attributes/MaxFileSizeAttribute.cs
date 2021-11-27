namespace InvoiceGenerator.Backend.Shared.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using Resources;

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize) => _maxFileSize = maxFileSize;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not IFormFile file) 
                return ValidationResult.Success;

            return file.Length > _maxFileSize 
                ? new ValidationResult(ErrorCodes.INVALID_FILE_SIZE) 
                : ValidationResult.Success;
        }
    }
}