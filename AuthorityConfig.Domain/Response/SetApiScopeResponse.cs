using IdentityServer4.Models;

namespace AuthorityConfig.Domain.Response
{
    public class SetApiScopeResponse
    {
        public bool Created { get; set; }
        public bool DryRun { get; set; }
        public ApiScope ApiScope { get; set; }
    }
}
