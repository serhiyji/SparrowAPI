using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparrowAPI.Core.DTOs.Category;

namespace SparrowAPI.Core.Validation.Category
{
    public class CreateCategoryValidation : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).WithMessage("Must be at least 2 characters");
        }
    }
}
