using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Abstractions.Repositories;
using Npgsql;

namespace Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task CreateAccount(long id, int password)
    {
        const string sql = """
                           INSERT INTO Accounts
                           VALUES :id, @password, 'User', 0
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
    }

    public async Task<int?> GetSystemKey()
    {
        const string sql = """
                           SELECT System_Key
                           FROM Admins
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync() is false) return null;
        return reader.GetInt32(0);
    }
}