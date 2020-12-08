using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityConfig.Domain.Response
{
    public class AuthorityConfigResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public AuthorityConfigResponse()
        {
            Success = true;
            ErrorMessage = string.Empty;
        }

        public AuthorityConfigResponse(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }

        public AuthorityConfigResponse(Exception ex)
        {
            Success = false;
            ErrorMessage = ex.Message;
        }

    }

}
