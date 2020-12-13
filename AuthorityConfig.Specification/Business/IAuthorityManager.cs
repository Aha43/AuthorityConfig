using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Business
{
    public interface IAuthorityManager
    {
        Task<Authorities> GetAuthoritiesAsync(CancellationToken cancellation);
        Task<Authority> GetAuthorityAsync(GetAuthorityParam param, CancellationToken cancellationToken);
        Task<IEnumerable<Client>> GetClientsAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task<IEnumerable<ApiScope>> GetApiScopesAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task<object> GetConfigurationAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken);
        Task SetClientAsync(SetClientParam param, CancellationToken cancellationToken);
        Task AddApiAsync(AddApiParam param, CancellationToken cancellationToken);
    }
}
