using AuthorityConfig.Infrastructure.AuthorityRepository.Sql.Config;
using AuthorityConfig.Specification.Repository;
using AuthorityConfig.Specification.Repository.Dao;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AuthorityConfig.Infrastructure.AuthorityRepository.Sql.IntegrationTest
{
    public class IntegrationTests
    {
        [Fact]
        public async Task AuthorityConfigShouldBeUpdatedAsync()
        {
            try
            {
                var (repo, jsonSample) = Configure();

                var testConf = new AuthorityDao
                {
                    Authority = "TestAuthority",
                    Description = "Test data",
                    Json = jsonSample,
                    Uri = "https://test-uri"
                };

                await repo.SetConfigurationAsync(testConf, CancellationToken.None);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static (IAuthorityRepository repo, string jsonSample) Configure()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<IntegrationTests>();

            var configuration = builder.Build();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureSqlAuthorityRepository(configuration);
            var sp = serviceCollection.BuildServiceProvider();

            var json = File.ReadAllText(configuration.GetSection("TestData")["ExampleJsonFilePath"]);

            return (sp.GetService<IAuthorityRepository>(), json);
        }

    }

}
