using Account.UseCases.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountAPI.EndPoints;

public static class Account
{
    public static void MapAccountEndPoints(this WebApplication app)
    {
        app.MapPost("/", async ([FromServices]IMediator mediator, [FromBody]CreateAccountRequest request) =>
        {
            var response = await mediator.Send(request);
            return response;
        });
    }
}
