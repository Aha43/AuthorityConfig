using AuthorityConfig.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Repository
{
    public interface IAuthorityRepository
    {
        Task<IdserverConfig> GetConfigurationAsync(string authority, CancellationToken cancellationToken);
        Task SetConfigurationAsync(string authority, IdserverConfig config, CancellationToken cancellationToken);
    }
}
