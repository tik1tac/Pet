using System.ComponentModel.DataAnnotations;
using FluentValidation;

public class AddValidatorUser : AbstractValidator<UserEntity>
{
    public AddValidatorUser()
    {
        RuleFor(p => p.PhoneNumber).NotEmpty();
        RuleFor(p => p.PhoneNumberConfirmed).NotEmpty();
        RuleFor(p => p.Password).NotEmpty();
        RuleFor(p => p.Wallet).LessThan(0);
        RuleFor(p => p.Email).EmailAddress().WithMessage("The Email must be unique");
        RuleFor(p => p.EmailConfirmed).NotNull();
    }
}