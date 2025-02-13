using Account.Entities;

namespace Account.UseCases.CreateAccount.Contracts;

public interface IRepository
{
    int Create(UserAccount request);
    bool VerifyIfExists(UserAccount request);
}