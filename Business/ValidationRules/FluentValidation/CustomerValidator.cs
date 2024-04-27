using Entitites.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.UserID).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(2);
        }
    }
}
