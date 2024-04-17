using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Abstractions.Repositories;
using Lab5.Models.Users;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserById(long? id)
    {
        const string sql = """
                           SELECT acc_id, acc_password, user_role, acc_balance
                           FROM Accounts
                           WHERE user_id = :id
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("acc_id", id);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync() is false) return null;
        return new User(
            Id: reader.GetInt64(0),
            Password: reader.GetInt32(1),
            Role: await reader.GetFieldValueAsync<UserRole>(2),
            Money: reader.GetInt64(3));
    }

    public async Task ReplenishAccount(long id, long sum)
    {
        const string sql = """
                           UPDATE Accounts
                           SET acc_balance = acc_balance + :sum
                           WHERE user_id = :id
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
    }

    public async Task WithdrawAccount(long id, long sum)
    {
        const string sql = """
                           UPDATE Accounts
                           SET acc_balance = acc_balance - :sum
                           WHERE user_id = :id
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
    }
}