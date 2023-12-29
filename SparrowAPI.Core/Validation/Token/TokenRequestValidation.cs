using FluentValidation;
using SparrowAPI.Core.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Validation.Token
{
    public class TokenRequestValidation : AbstractValidator<TokenRequestDto>
    {
        public TokenRequestValidation()
        {
            RuleFor(r => r.Token).NotEmpty();
            RuleFor(r => r.RefreshToken).NotEmpty();
        }
    }
}
