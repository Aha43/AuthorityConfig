using AuthorityConfig.Domain.Exceptions;

namespace AuthorityConfig.Domain.Oidc
{
    public static class OidcConstants
    {
        public static class Protocol
        {
            public const string Name = "oidc";
        }

        public static class Grants
        {
            public const string Password = "password";
            public const string AuthorizationCode = "authorization_code";
            public const string ClientCredentials = "client_credentials";
            public const string RefreshToken = "refresh_token";
            public const string Implicit = "implicit";
        }

    }

}
