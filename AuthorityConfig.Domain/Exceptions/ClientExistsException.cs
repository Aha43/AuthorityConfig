using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class ClientExistsException : Exception
    {
        public ClientExistsException(string message) : base(message) { }
    }
}
