using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios.AccountCreation;
using Presentation.Scenarios.AdminLogin;
using Presentation.Scenarios.CheckAccountMoney;
using Presentation.Scenarios.ReplenishMoney;
using Presentation.Scenarios.UserLogin;
using Presentation.Scenarios.WithdrawMoney;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AccountCreationScenarioProvider>();

        collection.AddScoped<IScenarioProvider, ReplenishMoneyScenarioProvider>();

        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CheckAccountMoneyScenarioProvider>();

        return collection;
    }
}