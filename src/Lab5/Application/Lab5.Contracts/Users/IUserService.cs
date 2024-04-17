namespace Lab5.Contracts.Users;

public interface IUserService
{
    Task<LoginResult> Login(long id, int password);

    Task<long> GetAccountBalance();

    Task<ReplenishResult> ReplenishAccount(long money);

    Task<WithdrawResult> WithdrawAccount(long money);
}