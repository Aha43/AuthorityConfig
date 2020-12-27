using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class ClientDoesNotExistsException : Exception
    {
        public ClientDoesNotExistsException(string clientId) : base("Client with id: '" + clientId + "' does not exists") { }
    }
}
