using Lab5.Models.Users;

namespace Lab5.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}