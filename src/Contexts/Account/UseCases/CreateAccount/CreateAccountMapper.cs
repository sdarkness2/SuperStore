using Account.Entities;
using AutoMapper;

namespace Account.UseCases.CreateAccount;

public class CreateAccountMapper : Profile
{
    public CreateAccountMapper()
    {
        CreateMap<CreateAccountRequest, UserAccount>();
        CreateMap<CreateAccountResponse, UserAccount>();
    }
}