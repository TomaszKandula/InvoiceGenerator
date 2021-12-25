namespace InvoiceGenerator.Backend.Core.Exceptions;

using System;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[Serializable]
public class InvoiceProcessingException : Exception
{
    public string ErrorCode { get; }

    protected InvoiceProcessingException(SerializationInfo serializationInfo, 
        StreamingContext streamingContext) : base(serializationInfo, streamingContext) { }

    public InvoiceProcessingException(string errorCode, string errorMessage = "") : base(errorMessage)
        => ErrorCode = errorCode;
}