using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty ");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty ");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty ");
            RuleFor(x => x.EmailAdrress).EmailAddress().WithMessage("Please enter a proper email address. ").NotEmpty().WithMessage("Username cannot be empty ");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty ");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("The name cannot be empty ");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Name can be maximum 30 character");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Name can be minimum 5 character");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Passwords do not match");

        }
    }

}
