using Lab5.Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.CheckAccountMoney;

public class CheckAccountMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public CheckAccountMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Check money on account";

    public async Task Run()
    {
        long result = await _userService.GetAccountBalance();

        string message = "Account balance: " + result;
        AnsiConsole.WriteLine(message);
    }
}