using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>, IValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(m => m.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(m => m.TcNo).NotEmpty().WithMessage("Tc number is required.");
            RuleFor(m => m.TcNo).Length(11).WithMessage("Tc number must be 11 characters.");
            RuleFor(m => m.DateOfBirth).NotEmpty().LessThan(DateTime.Now).WithMessage("Birth date is required.");
            RuleFor(m => m.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(m => m.Email).EmailAddress().WithMessage("Email is not valid.");

        }
    }
}
