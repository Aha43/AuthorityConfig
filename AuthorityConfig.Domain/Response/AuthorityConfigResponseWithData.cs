using System;

namespace AuthorityConfig.Domain.Response
{
    public class AuthorityConfigResponseWithData<T> : AuthorityConfigResponse
    {
        public T Data { get; set; }

        public AuthorityConfigResponseWithData(T data) : base()
        {
            Data = data;
        }

        public AuthorityConfigResponseWithData(string errorMessage) : base(errorMessage)
        {

        }

        public AuthorityConfigResponseWithData(Exception ex) : base(ex)
        {

        }

    }

}
