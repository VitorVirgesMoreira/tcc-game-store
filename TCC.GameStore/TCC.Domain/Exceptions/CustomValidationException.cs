using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TCC.GameStore.Domain.Exceptions
{
    [Serializable]
    public class CustomValidationException : AggregateException
    {
        public CustomValidationException(string message) : base(message) { }

        public CustomValidationException(IEnumerable<Exception> innerExceptions) : base(innerExceptions) { }

        [ExcludeFromCodeCoverage]
        protected CustomValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
