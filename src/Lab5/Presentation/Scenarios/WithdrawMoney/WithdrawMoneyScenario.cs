using Lab5.Contracts.Users;
using Spectre.Console;

namespace Presentation.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw money";

    public async Task Run()
    {
        long money = AnsiConsole.Ask<long>("Enter an amount of money to withdraw");

        WithdrawResult result = await _userService.WithdrawAccount(money);

        string message = result switch
        {
            WithdrawResult.Success => "Successful withdraw",
            WithdrawResult.NotFound => "User not found",
            WithdrawResult.LackOfMoney => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
    }
}