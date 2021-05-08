using FluentValidation;
using JWTAuthentication.Models;

namespace JWTAuthentication.Validators
{
    public class UserLoginDetailsValidator : AbstractValidator<UserLoginDetails>
    {
        public UserLoginDetailsValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
