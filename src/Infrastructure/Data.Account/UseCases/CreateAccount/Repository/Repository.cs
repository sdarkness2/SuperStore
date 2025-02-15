using Account.Entities;
using Account.UseCases.CreateAccount.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace Data.Account.UseCases.CreateAccount.Repository;

[ExcludeFromCodeCoverage]
public class Repository : IRepository
{
    List<UserAccount> _users = [];

    public int Create(UserAccount request)
    {
        int userCount = _users.Count;

        _users.Add(
            request
            );

        return _users.Count - userCount;
    }

    public bool VerifyIfExists(UserAccount request)
    {
        return _users.Any(_users => _users.Email == request.Email || _users.Name == request.Name);
    }
}
