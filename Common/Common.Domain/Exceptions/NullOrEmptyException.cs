using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
    public class NullOrEmptyException : BaseDomainException
    {
        public NullOrEmptyException() { }
        public NullOrEmptyException(string message) : base(message) { }
        
        public static void CheckNotEmpty(string message, string objectName)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new NullOrEmptyException($"{objectName} is null or empty.");
        }


    }
}
