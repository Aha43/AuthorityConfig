using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class ApiScopeExistsException : Exception 
    {
        public ApiScopeExistsException(string apiScope) : base("Api scope '" + apiScope + "' exists") { }
    }
}
