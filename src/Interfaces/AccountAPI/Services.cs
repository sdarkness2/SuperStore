using Account.UseCases.CreateAccount.Contracts;
using Data.Account.UseCases.CreateAccount.Repository;

namespace AccountAPI;

public static class Services
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository>();
    }
}
