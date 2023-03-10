using EvimiKur.UI.Models;
using FluentValidation;
using System;


namespace EvimiKur.UI.ValidationRules
{
    public class AppUserCreateModelValidator : AbstractValidator<AppUserCreateModel>
    {
        //[Obsolete]
        public AppUserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(3);
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x=>x.Gender).NotEmpty();
            
               
        
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Username cannot contain your name!").When(x => x.Username != null && x.Firstname != null);

        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }
       
        


    }
}
