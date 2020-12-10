using AuthorityConfig.Domain.Model;
using AuthorityConfig.Domain.Param;
using AuthorityConfig.Specification.Business;
using AuthorityConfig.Specification.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using AuthorityConfig.Specification.Repository.Dao;

namespace AuthorityConfig.Infrastructure.Manager
{
    public class AuthorityManager : IAuthorityManager
    {
        private readonly IAuthorityRepository _authorityRepository;

        public AuthorityManager(
            IAuthorityRepository authorityRepository)
        {
            _authorityRepository = authorityRepository;
        }

        public async Task<IdserverConfig> GetConfigurationAsync(GetConfigParam param, CancellationToken cancellationToken)
        {
            var stored = await _authorityRepository.GetConfigurationAsync(param.Authority, cancellationToken);
            if (stored == null)
            {
                return null;
            }
            var retVal = JsonSerializer.Deserialize<IdserverConfig>(stored.Json);
            return retVal;
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

    }

}
