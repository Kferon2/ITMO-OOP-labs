using Lab5.Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.ReplenishMoney;

public class ReplenishMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Replenish money";

    public async Task Run()
    {
        long money = AnsiConsole.Ask<long>("Enter an amount of money to replenish");

        ReplenishResult result = await _userService.ReplenishAccount(money);

        string message = result switch
        {
            ReplenishResult.Success => "Successful replenish",
            ReplenishResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}