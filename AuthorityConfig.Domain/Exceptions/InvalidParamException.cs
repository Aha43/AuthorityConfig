using System;

namespace AuthorityConfig.Domain.Exceptions
{
    public class InvalidParamException : Exception
    {
        public InvalidParamException(string message) : base(message) { }
        public InvalidParamException(Exception ex) : base(null, ex) { }
    }
}
