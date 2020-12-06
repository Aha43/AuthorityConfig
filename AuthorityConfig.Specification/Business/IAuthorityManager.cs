using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Business
{
    interface IAuthorityManager
    {
        Task<IdserverConfig> GetConfigurationAsync(GetConfigParam param, CancellationToken cancellationToken);
        Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken);
    }
}
