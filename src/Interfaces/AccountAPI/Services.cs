﻿using Account.Entities;
using Account.UseCases.CreateAccount.Contracts;
using Data.Account.UseCases.CreateAccount.Repository;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace AccountAPI;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository>();
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(UserAccount).Assembly));
        services.AddAutoMapper(x => x.AddMaps(typeof(UserAccount).Assembly));
        services.AddValidatorsFromAssembly(typeof(UserAccount).Assembly);
    }
}
