using Account.Entities;
using Account.UseCases.CreateAccount.Contracts;
using AutoMapper;
using MediatR;

namespace Account.UseCases.CreateAccount;

public class CreateAccountHandler(IMapper mapper, IRepository repository) : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<UserAccount>(request);

        if (repository.VerifyIfExists(user))
        {
            return new CreateAccountResponse(Message: "Usuário já existe");
        }

        repository.Create(user);

        return new CreateAccountResponse(Message: "Conta criada com sucesso");
    }
}
