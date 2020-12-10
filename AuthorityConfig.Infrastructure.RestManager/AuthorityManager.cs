using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Infrastructure.RestManager.Config;
using AuthorityConfig.Specification.Business;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace AuthorityConfig.Infrastructure.RestManager
{
    public class AuthorityManager : IAuthorityManager
    {
        private readonly UriProvider _restManagerConfig;

        public AuthorityManager(
            UriProvider restManagerConfig)
        {
            _restManagerConfig = restManagerConfig;
        }

        public async Task<IdserverConfig> GetConfigurationAsync(GetConfigParam param, CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            var uri = _restManagerConfig.AuthorityConfigAddress + "";
            var json = JsonSerializer.Serialize(param);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, requestContent);
            var resultContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IdserverConfig>(resultContent);
        }

        public Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetClientAsync(SetClientParam param, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }

}
