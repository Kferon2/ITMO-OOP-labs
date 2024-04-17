using System.Diagnostics.CodeAnalysis;
using Lab5.Contracts.Users;
using Lab5.Contracts.Users.Admins;
namespace Presentation.Scenarios.AdminLogin;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserService _currentUserService;

    public AdminLoginScenarioProvider(IAdminService adminService, ICurrentUserService currentUserService)
    {
        _adminService = adminService;
        _currentUserService = currentUserService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserService.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}