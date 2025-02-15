using Account.Entities;
using Account.UseCases.CreateAccount;
using Account.UseCases.CreateAccount.Contracts;
using AutoMapper;
using Moq;

namespace AccountUnitTests.UseCases.CreateAccount;

public class CreateAccountHandlerTest
{
    private Mock<IRepository> _repository = new();
    private IMapper _mapper;

    public CreateAccountHandlerTest()
    {
        var profile = new CreateAccountMapper();

        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));

        _mapper = new Mapper(configuration);
    }

    [Fact]
    public void CriarContaComSucesso()
    {
        var request = new CreateAccountRequest(
            Name: "José",
            Password: "12345678",
            Email: "josezinho123@gmail.com",
            BirthDate: DateOnly.FromDateTime(DateTime.Now.AddYears(-29))
        );

        _repository.Setup(x => x.VerifyIfExists(It.IsAny<UserAccount>())).Returns(false);

        _repository.Setup(x => x.Create(It.IsAny<UserAccount>())).Returns(1);

        CreateAccountHandler handler = new(_mapper, _repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "Conta criada com sucesso.");
    }

    [Fact]
    public void CriarContaComParametrosInvalidos()
    {
        var request = new CreateAccountRequest(
            Name: "Jo",
            Password: "1234567",
            Email: "josezinho123",
            BirthDate: DateOnly.FromDateTime(DateTime.Now)
        );

        CreateAccountHandler handler = new(_mapper, _repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "'Email' é um endereço de email inválido., 'Password' deve ter entre 8 e 20 caracteres. Você digitou 7 caracteres., 'Name' deve ter entre 3 e 20 caracteres. Você digitou 2 caracteres., Você precisa ter 18 anos ou mais.");
    }

    [Fact]
    public void CriarContaComEmailJaExistente()
    {
        var request = new CreateAccountRequest(
            Name: "José",
            Password: "12345678",
            Email: "josezinho123@gmail.com",
            BirthDate: DateOnly.FromDateTime(DateTime.Now.AddYears(-29))
        );

        _repository.Setup(x => x.VerifyIfExists(It.IsAny<UserAccount>())).Returns(true);

        CreateAccountHandler handler = new(_mapper, _repository.Object);

        var response = Task.Run(() => handler.Handle(request, default));

        Assert.True(response.Result.Message == "Usuário já existe.");
    }
}