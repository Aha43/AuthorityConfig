using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class FailedToCreateClientException : Exception
    {
        public FailedToCreateClientException(Exception ex) : base(null, ex) { }
    }
}
