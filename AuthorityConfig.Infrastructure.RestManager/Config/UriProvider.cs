using Microsoft.Extensions.Configuration;

namespace AuthorityConfig.Infrastructure.RestManager.Config
{
    public class UriProvider
    {
        public string AuthorityConfigAddress { get; }

        public UriProvider(IConfiguration configuration)
        {
            AuthorityConfigAddress = configuration.GetConnectionString("AuthorityConfigUri");
        }
    }

}
