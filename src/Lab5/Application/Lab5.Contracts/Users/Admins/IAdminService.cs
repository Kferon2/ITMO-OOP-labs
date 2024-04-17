namespace Lab5.Contracts.Users.Admins;

public interface IAdminService : IUserService
{
    Task<CreateAccountResult> CreateAccount(long id, int password);
}