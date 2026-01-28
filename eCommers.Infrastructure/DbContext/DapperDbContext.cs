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
            string connectionString = connectionStringTemplate
                .Replace("$POSTGRES_HOST",Environment.GetEnvironmentVariable("POSTGRES_HOST"))
                .Replace("$POSTGRES_PASSWORD",Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"))
                .Replace("$POSTGRES_DATABASE",Environment.GetEnvironmentVariable("POSTGRES_DATABASE"))
                .Replace("$POSTGRES_USER",Environment.GetEnvironmentVariable("POSTGRES_USER"))
                .Replace("$POSTGRES_PORT",Environment.GetEnvironmentVariable("POSTGRES_PORT"))
                ;
            _connection = new NpgsqlConnection(connectionString);
        }
        public IDbConnection DbConnection => _connection;
    }
}