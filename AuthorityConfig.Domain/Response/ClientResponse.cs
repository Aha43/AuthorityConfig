using IdentityServer4.Models;

namespace AuthorityConfig.Domain.Response
{
    public class ClientResponse
    {
        public bool Created { get; set; }
        public string Secret { get; set; }
        public Client Client { get; set; }
    }
}
