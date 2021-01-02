using IdentityServer4.Models;

namespace AuthorityConfig.Domain.Response
{
    public class SetClientResponse
    {
        public bool Created { get; set; }
        public bool DryRun { get; set; }
        public string Secret { get; set; }
        public Client Client { get; set; }
    }
}
