using EvimiKur.Dtos.ProductStatusDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.ValidationRules.ProductStatusValidation
{
    public class ProductStatusCreateDtoValidator : AbstractValidator<ProductStatusCreateDto>
    {
        public ProductStatusCreateDtoValidator()
        {

        }
    }
}
