using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using exanim.core.DTOs;

namespace exanim.web.Utils;

public static class AuthMeExtensions
{
    extension(ClaimsPrincipal m)
    {
        public AuthMe ToAuth()
        {
            var id = m.Claims
                .FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.NameId)?.Value;
            var ida = m.Claims
                .FirstOrDefault(t => t.Type == JwtRegisteredClaimNames.FamilyName)?.Value;
            return new AuthMe(Guid.Parse(id!),
                string.IsNullOrEmpty(ida) ? null : Guid.Parse(ida));
        }
    }
}