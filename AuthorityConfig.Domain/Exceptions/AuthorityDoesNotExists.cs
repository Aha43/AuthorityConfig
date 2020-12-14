using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class AuthorityDoesNotExists : Exception
    {
        public AuthorityDoesNotExists(string authority) : base("Authority '" + authority + "' does not exists") { }
    }
}
