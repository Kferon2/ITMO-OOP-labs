using ConsoleApp;
using Infrastructure.Extensions;
using Lab5.Application.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extensions;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = Config.Host;
        configuration.Port = Config.Port;
        configuration.Username = Config.UserName;
        configuration.Password = Config.Password;
        configuration.Database = Config.DataBase;
        configuration.SslMode = Config.SslMode;
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}