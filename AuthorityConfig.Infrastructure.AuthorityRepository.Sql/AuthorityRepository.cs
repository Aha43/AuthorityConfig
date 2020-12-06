using AuthorityConfig.Infrastructure.AuthorityRepository.Sql.Config;
using AuthorityConfig.Specification.Repository;
using AuthorityConfig.Specification.Repository.Dao;
using Dapper;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AuthorityConfig.Infrastructure.AuthorityRepository.Sql
{
    public class AuthorityRepository : IAuthorityRepository
    {
        private readonly DbConnectionProvider _connectionProvider;

        public AuthorityRepository(
            DbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<AuthorityDao> GetConfigurationAsync(string authority, CancellationToken cancellationToken)
        {
            var procedure = "authconfig.pr__get_configuration";
            using (var con = _connectionProvider.GetSqlConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("authority", authority, DbType.String);
                
                return await con.QueryFirstOrDefaultAsync<AuthorityDao>(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task SetConfigurationAsync(AuthorityDao config, CancellationToken cancellationToken)
        {
            var procedure = "authconfig.pr__set_configuration";
            using (var con = _connectionProvider.GetSqlConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("authority", config.Authority, DbType.String);
                parameters.Add("json", config.Json, DbType.String);
                parameters.Add("uri", config.Uri, DbType.String);
                parameters.Add("description", config.Description, DbType.String);

                await con.QueryAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }

}
