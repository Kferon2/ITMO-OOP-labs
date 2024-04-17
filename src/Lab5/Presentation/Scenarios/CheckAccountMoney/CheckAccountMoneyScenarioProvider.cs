using System.Diagnostics.CodeAnalysis;
using Lab5.Contracts.Users;

namespace Presentation.Scenarios.CheckAccountMoney;

public class CheckAccountMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public CheckAccountMoneyScenarioProvider(ICurrentUserService currentUserService, IUserService userService)
    {
        _currentUserService = currentUserService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckAccountMoneyScenario(_userService);
        return true;
    }
}