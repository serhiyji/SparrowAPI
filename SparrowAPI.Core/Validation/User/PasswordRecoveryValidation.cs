using FluentValidation;
using SparrowAPI.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Validation.User
{
    public class PasswordRecoveryValidation : AbstractValidator<PasswordRecoveryDto>
    {
        public PasswordRecoveryValidation()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).Equal(r => r.ConfirmPassword);
        }
    }
}
