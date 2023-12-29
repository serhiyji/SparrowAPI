using FluentValidation;
using SparrowAPI.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Validation.User
{
    public class UpdatePasswordValidation : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordValidation() 
        {
            RuleFor(r => r.OldPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.NewPassword).MinimumLength(6).NotEmpty();
            RuleFor(r => r.ConfirmPassword).MinimumLength(6).Equal(r => r.NewPassword).NotEmpty();
        }
    }
}
