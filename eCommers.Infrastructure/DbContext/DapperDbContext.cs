using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommers.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            string connectionStringTemplate = configuration.GetConnectionString("PostgresConnection")!;
            string connectionString = connectionStringTemplate.Replace("$POSTGRES_HOST",Environment.GetEnvironmentVariable("POSTGRES_HOST")).Replace("$POSTGRES_PASSWORD",Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));
            _connection = new NpgsqlConnection(connectionString);
        }
        public IDbConnection DbConnection => _connection;
    }
}