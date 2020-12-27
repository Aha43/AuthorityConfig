using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class AuthorityDoesNotExistsException : Exception
    {
        public AuthorityDoesNotExistsException(string authority) : base("Authority '" + authority + "' does not exists") { }
    }
}
