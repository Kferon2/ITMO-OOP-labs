namespace Lab5.Abstractions.Repositories;

public interface IAdminRepository
{
    Task CreateAccount(long id, int password);

    Task<int?> GetSystemKey();
}