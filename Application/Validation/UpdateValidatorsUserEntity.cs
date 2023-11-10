using FluentValidation;

public class UpdateValidatorUser : AbstractValidator<UserEntity>
{
    public UpdateValidatorUser()
    {
        RuleFor(p => p.Wallet).LessThan(0);
    }
}