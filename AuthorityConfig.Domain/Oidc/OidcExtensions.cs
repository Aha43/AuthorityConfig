using AuthorityConfig.Domain.Exceptions;
using static AuthorityConfig.Domain.Oidc.OidcConstants;

namespace AuthorityConfig.Domain.Oidc
{
    public static class OidcExtensions
    {
        public static string ValidGrant(this string grant)
        {
            if (Grants.Password.Equals(grant)) return grant;
            if (Grants.AuthorizationCode.Equals(grant)) return grant;
            if (Grants.ClientCredentials.Equals(grant)) return grant;
            if (Grants.RefreshToken.Equals(grant)) return grant;
            if (Grants.Implicit.Equals(grant)) return grant;
            throw new InvalidGrantException(grant);
        }

        public static string[] ValidGrants(this string grants, bool allowNoGrants = false)
        {
            var retVal = (grants ?? string.Empty).Split(' ');
            if (!allowNoGrants && retVal.Length == 0)
            {
                throw new NoGrantsGivenException();
            }

            foreach (var grant in retVal) _ = ValidGrant(grant);

            return retVal;
        } 

    }

}
