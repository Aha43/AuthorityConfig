using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthorityConfig.Tool.AuthYamlToJson
{
    public class IdserverConfig
    {
        public IEnumerable<Client> Clients { get; set; } = new Client[] { };
        public IEnumerable<ApiScope> Apis { get; set; } = new ApiScope[] { };
        public IEnumerable<IdentityResource> IdentityResources { get; set; } = new IdentityResource[] { };
        public IEnumerable<IdProviderOptions> IdProviders { get; set; } = new IdProviderOptions[] { };

        public bool EnableLocalLogin { get; set; }
        public bool EnableWindowsAuthentication { get; set; }

        public bool ShowNewPasswordLink { get; set; } = true;
        public bool NoUserPasswordButton { get; set; } = false;
        public bool MobileFirst { get; set; } = false;
    }
}
