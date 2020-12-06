using AuthorityConfig.Specification.Repository.Dao;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Specification.Repository
{
    public interface IAuthorityRepository
    {
        Task<AuthorityDao> GetConfigurationAsync(string authority, CancellationToken cancellationToken);
        Task SetConfigurationAsync(AuthorityDao config, CancellationToken cancellationToken);
    }
}
