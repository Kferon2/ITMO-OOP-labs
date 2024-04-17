using Lab5.Abstractions.Repositories;
using Lab5.Contracts.Users;
using Lab5.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IAccountRepository accountRepository, CurrentUserManager currentUserManager)
    {
        _accountRepository = accountRepository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(long id, int password)
    {
        User? user = await _accountRepository.FindUserById(id);

        if (user is null) return LoginResult.NotFound;

        if (user.Password != password) return LoginResult.WrongPassword;

        _currentUserManager.User = user;
        return LoginResult.Success;
    }

    public async Task<long> GetAccountBalance()
    {
        if (_currentUserManager.User is null) return 0;
        User? user = await _accountRepository.FindUserById(_currentUserManager.User.Id);
        if (user is null) return 0;
        return user.Money;
    }

    public async Task<ReplenishResult> ReplenishAccount(long money)
    {
        if (_currentUserManager.User is null) return ReplenishResult.NotFound;
        User? user = await _accountRepository.FindUserById(_currentUserManager.User.Id);
        if (user is null) return ReplenishResult.NotFound;
        await _accountRepository.ReplenishAccount(_currentUserManager.User.Id, money);
        return ReplenishResult.Success;
    }

    public async Task<WithdrawResult> WithdrawAccount(long money)
    {
        if (_currentUserManager.User is null) return WithdrawResult.NotFound;
        User? user = await _accountRepository.FindUserById(_currentUserManager.User.Id);
        if (user is null) return WithdrawResult.NotFound;
        if (user.Money < money) return WithdrawResult.LackOfMoney;
        await _accountRepository.WithdrawAccount(_currentUserManager.User.Id, money);
        return WithdrawResult.Success;
    }
}