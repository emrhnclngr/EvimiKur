using EvimiKur.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.ValidationRules.AddressValidation
{
    public class AddressCreateDtoValidator : AbstractValidator<AddressCreateDto>
    {
        public AddressCreateDtoValidator()
        {

        }
    }
}
