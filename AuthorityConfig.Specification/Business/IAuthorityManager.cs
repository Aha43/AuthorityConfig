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
        Task<object> GetConfigurationAsync(AuthorityParam param, CancellationToken cancellationToken);
        Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken);
    }
}
