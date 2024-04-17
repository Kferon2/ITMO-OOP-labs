using System.Diagnostics.CodeAnalysis;
using Lab5.Contracts.Users;

namespace Presentation.Scenarios.UserLogin;

public class UserLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUserService;

    public UserLoginScenarioProvider(IUserService userService, ICurrentUserService currentUserService)
    {
        _userService = userService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new UserLoginScenario(_userService);
        return true;
    }
}