using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using AuthorityConfig.Specification.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using AuthorityConfig.Specification.Repository.Dao;
using System.Linq;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthorityConfig.Infrastructure.DIPS.Front.Manager
{
    public class AuthorityManager : IAuthorityManager
    {
        private readonly IAuthorityRepository _authorityRepository;

        public AuthorityManager(
            IAuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
        }

        private async Task<IdserverConfig> GetConfigurationAsync(string authority, CancellationToken cancellationToken)
        {
            var stored = await _authorityRepository.GetConfigurationAsync(authority, cancellationToken);
            if (stored == null)
            {
                return null;
            }
            var retVal = JsonSerializer.Deserialize<IdserverConfig>(stored.Json);
            return retVal;
        }

        private async Task SetConfigurationAsync(string authority, CancellationToken cancellationToken, IdserverConfig config = null, string uri = null, string description = null)
        {
            var dao = new AuthorityDao
            {
                Authority = authority,
                Json = (config == null) ? null : JsonSerializer.Serialize(config),
                Uri = uri,
                Description = description
            };

            await _authorityRepository.SetConfigurationAsync(dao, cancellationToken);
        }

        public async Task<object> GetConfigurationAsync(GetConfigParam param, CancellationToken cancellationToken)
        {
            return await GetConfigurationAsync(param.Authority, cancellationToken);
        }

        public async Task SetConfigurationAsync(SetConfigParam param, CancellationToken cancellationToken)
        {
            var dao = new AuthorityDao
            {
                Authority = param.Authority,
                Json = JsonSerializer.Serialize(param.Config),
                Uri = param.Uri,
                Description = param.Description
            };

            await _authorityRepository.SetConfigurationAsync(dao, cancellationToken);
        }

        public async Task SetClientAsync(SetClientParam param, CancellationToken cancellationToken)
        {
            var config = await GetConfigurationAsync(param.Authority, cancellationToken);
            if (config == null)
            {
                throw new Exception("Authority " + param.Authority + " not found");
            }

            var client = GetClient(config, param);

            AddScopes(client, param);
            // ToDo: More modificators

            await SetConfigurationAsync(authority: param.Authority, config: config, cancellationToken: cancellationToken);
        }

        #region set_client_support
        private Client GetClient(IdserverConfig config, SetClientParam param)
        {
            var retVal = config.Clients.Where(c => c.ClientId.Equals(param.ClientId)).FirstOrDefault();
            if (retVal == null)
            {
                return CreateClient(config, param);
            }

            return retVal;
        }

        private Client CreateClient(IdserverConfig config, SetClientParam param)
        {
            throw new NotImplementedException("not yet...");
        }

        private void AddScopes(Client client, SetClientParam param)
        {
            var scopesToAdd = param.ScopesToAdd;
            if (!string.IsNullOrWhiteSpace(scopesToAdd))
            {
                var scopesToAddSet = new HashSet<string>(scopesToAdd.Split(' '));
                var existingScopes = new HashSet<string>(client.AllowedScopes == null ? new string[] { } : client.AllowedScopes);
                var newScopes = existingScopes.Union(scopesToAddSet);
                client.AllowedScopes = newScopes.ToArray();
            }
        }
        #endregion

        public async Task AddApiAsync(AddApiParam param, CancellationToken cancellationToken)
        {
            var config = await GetConfigurationAsync(param.Authority, cancellationToken);
            if (config == null)
            {
                throw new Exception("Authority " + param.Authority + " not found");
            }

            var api = config.Apis == null ? null : config.Apis.Where(a => a.Name.Equals(param.Name)).FirstOrDefault();
            if (api != null)
            {
                throw new Exception("Api exists");
            }

            api = new ApiScope
            {
                Name = param.Name,
                DisplayName = string.IsNullOrWhiteSpace(param.DisplayName) ? param.Name : param.DisplayName
            };

            var newApis = new List<ApiScope>();
            if (config.Apis != null) newApis.AddRange(config.Apis);
            newApis.Add(api);
            config.Apis = newApis;

            await SetConfigurationAsync(authority: param.Authority, config: config, cancellationToken: cancellationToken);
        }

        public async Task<Authorities> GetAuthoritiesAsync(CancellationToken cancellationToken)
        {
            var names = await _authorityRepository.GetAuthorityNames(cancellationToken);
            return new Authorities { Names = names };
        }

        public async Task<Authority> GetAuthorityAsync(GetAuthorityParam param, CancellationToken cancellationToken)
        {
            var stored = await _authorityRepository.GetConfigurationAsync(param.Authority, cancellationToken);
            return new Authority
            {
                Description = stored.Description,
                Name = stored.Authority,
                Uri = stored.Uri
            };
        }

    }

}
