using Account.UseCases.CreateAccount.Contracts;
using Data.Account.UseCases.CreateAccount.Repository;
using System.Diagnostics.CodeAnalysis;

namespace AccountAPI;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository>();
    }
}
