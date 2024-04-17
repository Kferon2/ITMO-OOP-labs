using System.Diagnostics.CodeAnalysis;
using Lab5.Contracts.Users;

namespace Presentation.Scenarios.ReplenishMoney;

public class ReplenishMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public ReplenishMoneyScenarioProvider(ICurrentUserService currentUserService, IUserService userService)
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

        scenario = new ReplenishMoneyScenario(_userService);
        return true;
    }
}