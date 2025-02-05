using MediatR;

namespace Account.UseCases.CreateAccount;

public sealed record CreateAccountRequest(string Name, string Password, string Email, DateTime BrithDate)
    : IRequest<CreateAccountResponse>;
