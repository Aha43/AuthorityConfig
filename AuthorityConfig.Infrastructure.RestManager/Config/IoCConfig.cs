using AuthorityConfig.Specification.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorityConfig.Infrastructure.RestManager.Config
{
    public static class IoCConfig
    {
        public static IServiceCollection ConfigureRestManagerServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(new UriProvider(configuration))
                .AddSingleton<IAuthorityManager, AuthorityManager>();
        }
    }
}
