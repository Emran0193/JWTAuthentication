using FluentValidation;
using JWTAuthentication.Models;
using System;

namespace JWTAuthentication.Validators
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
