using System.Threading.Tasks;
using Lab5.Abstractions.Repositories;
using Lab5.Application.Users;
using Lab5.Models.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    [Fact]
    public async Task FirstTestCase()
    {
        // Arrange
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var user = new User(1, 123, UserRole.User, 100);
        var currentUserManager = new CurrentUserManager
        {
            User = user,
        };
        var service = new UserService(repository, currentUserManager);

        // Act
        await service.WithdrawAccount(500);

        // Assert
        await repository.DidNotReceive().WithdrawAccount(1, 500);
    }

    [Fact]
    public async Task SecondTestCase()
    {
        // Arrange
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var user = new User(1, 123, UserRole.User, 100);
        var currentUserManager = new CurrentUserManager
        {
            User = user,
        };
        var service = new UserService(repository, currentUserManager);

        // Act
        await service.WithdrawAccount(50);

        // Assert
        await repository.DidNotReceive().WithdrawAccount(1, 50);
    }

    [Fact]
    public async Task ThirdTestCase()
    {
        // Arrange
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var user = new User(1, 123, UserRole.User, 100);
        var currentUserManager = new CurrentUserManager
        {
            User = user,
        };
        var service = new UserService(repository, currentUserManager);

        // Act
        await service.ReplenishAccount(50);

        // Assert
        await repository.DidNotReceive().ReplenishAccount(1, 50);
    }
}