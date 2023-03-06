using EvimiKur.UI.Models;
using FluentValidation;

namespace EvimiKur.UI.ValidationRules
{
    public class ProductCreateModelValidator : AbstractValidator<ProductCreateModel>
    {
        public ProductCreateModelValidator()
        {
            RuleFor(x=>x.CategoryId).NotEmpty();
        }
    }
}
