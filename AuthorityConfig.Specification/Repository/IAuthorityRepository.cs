using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Repository
{
    public interface IAuthorityRepository
    {
        Task<object> GetConfigurationAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken);


        // NEW API
        #region authorities
        Task<Authorities> GetAuthoritiesAsync(CancellationToken cancellation);
        Task<Authority> GetAuthorityAsync(GetAuthorityParam param, CancellationToken cancellationToken);
        #endregion

        #region client
        Task<IEnumerable<Client>> GetClientsAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task<Client> GetClientAsync(GetClientParam param, CancellationToken cancellationToken);
        Task SetClientAsync(Client client, SetClientParam param, CancellationToken cancellationToken);
        #endregion

        #region api
        Task<IEnumerable<ApiScope>> GetApiScopesAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task<ApiScope> GetApiScopeAsync(GatApiScopeParam param, CancellationToken cancellationToken);
        Task SetApiScopeAsync(ApiScope apiScope, SetApiParam param, CancellationToken cancellationToken);
        #endregion
    }
}
