using Lab5.Models.Users;

namespace Lab5.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<User?> FindUserById(long? id);

    Task ReplenishAccount(long id, long sum);

    Task WithdrawAccount(long id, long sum);
}