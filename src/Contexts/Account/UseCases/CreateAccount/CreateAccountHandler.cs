using Account.Entities;
using AutoMapper;
using MediatR;

namespace Account.UseCases.CreateAccount;

public class CreateAccountHandler(IMapper mapper) : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
{
    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<UserAccount>(request);

        return mapper.Map<CreateAccountResponse>(user);
    }
}
