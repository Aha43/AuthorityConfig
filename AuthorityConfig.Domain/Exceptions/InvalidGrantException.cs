using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class InvalidGrantException : Exception
    {
        public InvalidGrantException(string grant) : base("Invalid grant: " + grant) { }
    }
}
