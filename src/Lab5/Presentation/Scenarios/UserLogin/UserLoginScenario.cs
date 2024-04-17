using Lab5.Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.UserLogin;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login as user";

    public async Task Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter your Id");

        int userPassword = AnsiConsole.Ask<int>("Enter your password");

        LoginResult result = await _userService.Login(userId, userPassword);

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