using Lab5.Contracts.Users.Admins;
using Spectre.Console;

namespace Presentation.Scenarios.AccountCreation;

public class AccountCreationScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AccountCreationScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as admin";

    public async Task Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter new Id");

        int userPassword = AnsiConsole.Ask<int>("Enter new password");

        CreateAccountResult result = await _adminService.CreateAccount(userId, userPassword);

        string message = result switch
        {
            CreateAccountResult.Success => "Successful creation",
            CreateAccountResult.AccountExists => "Account already exists",
            CreateAccountResult.NotFound => "There is no admin",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}