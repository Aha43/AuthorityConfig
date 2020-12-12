using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Business
{
    public interface IAuthorityManager
    {
        Task<Authorities> GetAuthoritiesAsync(CancellationToken cancellation);
        Task<Authority> GetAuthorityAsync(GetAuthorityParam param, CancellationToken cancellationToken);
        Task<IdserverConfig> GetConfigurationAsync(GetConfigParam param, CancellationToken cancellationToken);
        Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken);
        Task SetClientAsync(SetClientParam param, CancellationToken cancellationToken);
        Task AddApiAsync(AddApiParam param, CancellationToken cancellationToken);
    }
}
