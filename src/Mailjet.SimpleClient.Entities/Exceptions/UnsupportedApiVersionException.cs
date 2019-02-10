using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Exceptions
{
    public class UnsupportedApiVersionException : Exception
    {
        public UnsupportedApiVersionException()
        {
        }

        public UnsupportedApiVersionException(string message) : base(message)
        {
        }

        public UnsupportedApiVersionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedApiVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
