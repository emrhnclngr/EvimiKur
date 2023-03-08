using EvimiKur.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.ValidationRules.ProductValidation
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.QuantityPerUnit).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.UnitInStock).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            
            

        }
    }
}
