using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AuthorityConfig.Infrastructure.AuthorityRepository.Sql.Config
{
    public class DbConnectionProvider
    {
        private readonly string _connectionString;

        public DbConnectionProvider(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Authority");
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }

}
