using Lab5.Contracts.Users;
using Lab5.Models.Users;

namespace Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}