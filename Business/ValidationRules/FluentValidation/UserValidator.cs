using Entitites.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(2);
            RuleFor(u => u.Password).NotEmpty();

        }
    }
}
