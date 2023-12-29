using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparrowAPI.Core.DTOs.Token;
using SparrowAPI.Core.Entities.Token;
using SparrowAPI.Core.Entities.User;
using SparrowAPI.Core.Services;

namespace SparrowAPI.Core.Interfaces
{
    public interface IJwtService
    {
        Task Create(RefreshToken token);
        Task Delete(RefreshToken token);
        Task Update(RefreshToken token);
        Task<RefreshToken?> Get(string token);
        Task<IEnumerable<RefreshToken>> GetAll();
        Task<Tokens> GenerateJwtTokensAsync(AppUser user);
        Task<ServiceResponse> VerifyTokenAsync(TokenRequestDto tokenRequest);
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId);
    }
}
