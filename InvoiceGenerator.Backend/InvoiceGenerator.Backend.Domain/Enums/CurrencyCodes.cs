namespace InvoiceGenerator.Backend.Domain.Enums
{
    using System.Runtime.Serialization;

    public enum CurrencyCodes
    {
        [EnumMember(Value = "unknown")]
        Unknown,

        [EnumMember(Value = "bgn")]
        Bgn,

        [EnumMember(Value = "chf")]
        Chf,

        [EnumMember(Value = "czk")]
        Czk,

        [EnumMember(Value = "dkk")]
        Dkk,

        [EnumMember(Value = "eur")]
        Eur,

        [EnumMember(Value = "gdp")]
        Gbp,

        [EnumMember(Value = "hrk")]
        Hrk,

        [EnumMember(Value = "huf")]
        Huf,

        [EnumMember(Value = "nok")]
        Nok,

        [EnumMember(Value = "pln")]
        Pln,

        [EnumMember(Value = "ron")]
        Ron,

        [EnumMember(Value = "sek")]
        Sek,

        [EnumMember(Value = "try")]
        Try,

        [EnumMember(Value = "usd")]
        Usd
    }
}