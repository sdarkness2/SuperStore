using FluentValidation;

namespace Account.UseCases.CreateAccount;

public sealed class CreateAcccountValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAcccountValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid e-mail.");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(20).WithMessage("Invalid password.");
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Invalid name.");
        RuleFor(x => x.BrithDate).Must(ValidAge).WithMessage("Invalid age.");
    }

    private bool ValidAge(DateTime date)
    {
        int age = DateTime.Now.Year - date.Year;
        if (age < 18)
            return false;
        return true;
    }
}