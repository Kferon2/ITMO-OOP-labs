using Lab5.Contracts.Users;
using Lab5.Contracts.Users.Admins;
using Spectre.Console;

namespace Presentation.Scenarios.AdminLogin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as admin";

    public async Task Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter your Id");

        int userPassword = AnsiConsole.Ask<int>("Enter your password");

        LoginResult result = await _adminService.Login(userId, userPassword);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            LoginResult.WrongPassword => "Wrong password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}