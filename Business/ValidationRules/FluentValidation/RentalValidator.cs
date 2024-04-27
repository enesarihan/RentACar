using Entitites.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.RentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
