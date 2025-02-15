using MediatR;

namespace Account.UseCases.CreateAccount;

public sealed record CreateAccountRequest(string Name, string Password, string Email, DateOnly BirthDate)
    : IRequest<CreateAccountResponse>;
