using Lab5.Abstractions.Repositories;
using Lab5.Contracts.Users;
using Lab5.Contracts.Users.Admins;
using Lab5.Models.Users;

namespace Lab5.Application.Users.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentUserManager _currentUserManager;

    public AdminService(
        IAdminRepository adminRepository,
        IAccountRepository accountRepository,
        CurrentUserManager currentUserManager)
    {
        _adminRepository = adminRepository;
        _accountRepository = accountRepository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(long id, int password)
    {
        User? user = await _accountRepository.FindUserById(id);

        if (user is null) return LoginResult.NotFound;

        if (await _adminRepository.GetSystemKey() != password) return LoginResult.WrongPassword;

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

    public async Task<CreateAccountResult> CreateAccount(long id, int password)
    {
        if (_currentUserManager.User is null) return CreateAccountResult.NotFound;
        User? user = await _accountRepository.FindUserById(_currentUserManager.User.Id);
        if (user is null) return CreateAccountResult.NotFound;
        if (await _accountRepository.FindUserById(id) is not null) return CreateAccountResult.AccountExists;
        await _adminRepository.CreateAccount(id, password);
        return CreateAccountResult.Success;
    }
}