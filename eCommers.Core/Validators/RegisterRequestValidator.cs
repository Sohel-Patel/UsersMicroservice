using eCommers.Core.DTO;
using FluentValidation;

namespace eCommers.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest> 
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format.");  
            
            RuleFor(x => x.Gender).IsInEnum();

            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name is required.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}