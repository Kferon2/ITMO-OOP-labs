using System.Diagnostics.CodeAnalysis;
using Lab5.Contracts.Users;
using Lab5.Contracts.Users.Admins;
using Lab5.Models.Users;

namespace Presentation.Scenarios.AccountCreation;

public class AccountCreationScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserService _currentUserService;

    public AccountCreationScenarioProvider(IAdminService adminService, ICurrentUserService currentUserService)
    {
        _adminService = adminService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is null || _currentUserService.User.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new AccountCreationScenario(_adminService);
        return true;
    }
}