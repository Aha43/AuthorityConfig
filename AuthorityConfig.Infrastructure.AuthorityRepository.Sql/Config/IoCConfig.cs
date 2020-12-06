using AuthorityConfig.Specification.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorityConfig.Infrastructure.AuthorityRepository.Sql.Config
{
    public static class IoCConfig
    {
        public static IServiceCollection ConfigureSqlAuthorityRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.AddSingleton(new DbConnectionProvider(configuration))
                .AddSingleton<IAuthorityRepository, AuthorityRepository>();
        }

    }

}
