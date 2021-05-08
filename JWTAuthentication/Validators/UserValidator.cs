using FluentValidation;
using JWTAuthentication.Models;
using System;

namespace JWTAuthentication.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private bool BeAValidDate(DateTime value)
        {
            DateTime date;
            return DateTime.TryParse(value.ToString(), out date);
        }
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.DateOfBirth).NotEmpty().Must(BeAValidDate).WithMessage("Invalid date/time"); ;
            RuleFor(p => p.Address).NotEmpty();
            RuleFor(p => p.RoleId).NotEmpty();
            RuleFor(p => p.MobileNumber).NotEmpty().MinimumLength(14);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Password).NotEmpty();
        }        
    }
}
