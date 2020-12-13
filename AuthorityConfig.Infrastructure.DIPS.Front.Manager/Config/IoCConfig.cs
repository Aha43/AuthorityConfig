using AuthorityConfig.Specification.Business;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorityConfig.Infrastructure.DIPS.Front.Manager.Config
{
    public static class IoCConfig
    {
        public static IServiceCollection ConfigureManagerServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSingleton<IAuthorityManager, AuthorityManager>();
        }

    }

}
