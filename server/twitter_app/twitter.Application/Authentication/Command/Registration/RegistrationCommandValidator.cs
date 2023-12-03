using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Application.Authentication.Command.Registration
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        public RegistrationCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Year).NotEmpty();
            RuleFor(x => x.Month).NotEmpty();
            RuleFor(x => x.Day).NotEmpty();
        }
    }
}
