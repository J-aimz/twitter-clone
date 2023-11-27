using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Infrastructure.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base("Forbidden")
        {
        }

        public ForbiddenAccessException(string message) : base(message)
        {
        }

        protected ForbiddenAccessException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
