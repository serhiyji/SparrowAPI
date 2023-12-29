using SparrowAPI.Core.Entities.User;
using SparrowAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Entities.Token
{
    public class RefreshToken : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string JwtId { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public AppUser User { get; set; }
    }
}
