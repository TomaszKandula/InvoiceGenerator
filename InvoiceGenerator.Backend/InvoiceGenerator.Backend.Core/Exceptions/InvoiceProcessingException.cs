using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace InvoiceGenerator.Backend.Core.Exceptions;

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