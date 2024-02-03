using FluentValidation.Results;
using InvoiceGenerator.Services.VatService.Models;

namespace InvoiceGenerator.Services.VatService;

public interface IVatService
{
    ValidationResult ValidateVatNumber(VatValidationRequest request);
}