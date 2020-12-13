using AuthorityConfig.Infrastructure.AuthorityRepository.Sql.Config;
using AuthorityConfig.Infrastructure.DIPS.Front.Manager.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DipsFrontAuthorityConfig.Config
{
    public static class IoCConfig
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.ConfigureSqlAuthorityRepository(configuration)
                .ConfigureManagerServices();
        }

    }

}
