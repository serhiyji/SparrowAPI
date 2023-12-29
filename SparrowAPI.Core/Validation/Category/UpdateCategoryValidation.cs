using FluentValidation;
using SparrowAPI.Core.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Validation.Category
{
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).WithMessage("Must be at least 2 characters");
        }
    }
}
