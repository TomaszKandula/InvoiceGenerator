namespace InvoiceGenerator.Backend.Shared.Dto.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Domain.Enums;

[ExcludeFromCodeCoverage]
public class OrderDetailBase<T>
{
    public DateTime? VoucherDate { get; set; }

    public DateTime? ValueDate { get; set; }

    public int PaymentTerms { get; set; }

    public PaymentTypes PaymentType { get; set; }

    public PaymentStatuses PaymentStatus { get; set; }

    public string CompanyName { get; set; }

    public string CompanyVatNumber { get; set; }

    public CountryCodes CountryCode { get; set; }

    public string City { get; set; }

    public string StreetAddress { get; set; }

    public string PostalCode { get; set; }

    public string PostalArea { get; set; }

    public string InvoiceTemplateName { get; set; }

    public CurrencyCodes CurrencyCode { get; set; }

    public IEnumerable<T> InvoiceItems { get; set; }
}