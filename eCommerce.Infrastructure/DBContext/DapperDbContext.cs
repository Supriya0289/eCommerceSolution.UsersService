

using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DBContext;

    public class DapperDbContext
    {
    private readonly IConfiguration _configuration;
    private readonly IDbConnection dbConnection;
        public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

       dbConnection= new NpgsqlConnection(connectionString);
    }
    public IDbConnection DbConnection => dbConnection;
    }

