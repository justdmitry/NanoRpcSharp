namespace NanoRpcSharp
{
    using System;
    using System.Runtime.Serialization;

    public class ErrorResponseException : Exception
    {
        public ErrorResponseException()
            : base()
        {
            // Nothing
        }

        public ErrorResponseException(string message)
            : base(message)
        {
            // Nothing
        }

        public ErrorResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
            // Nothing
        }

        protected ErrorResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Nothing
        }
    }
}
