using AuthorityConfig.Domain.Param;
using AuthorityConfig.Domain.Response;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Business
{
    public interface IClientManager
    {
        Task<IEnumerable<Client>> GetClientsAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task<ClientResponse> SetClientAsync(SetClientParam param, CancellationToken cancellationToken);
    }
}
