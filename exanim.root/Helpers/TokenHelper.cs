using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exanim.core.Helpers;
using exanim.core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace exanim.root.Helpers;

public sealed class TokenHelper : ITokenHelper
{
    private readonly JwtSetting _settings;
    private readonly JwtSecurityTokenHandler _handler = new();
    private readonly SymmetricSecurityKey _signingKey;
    private readonly TokenValidationParameters _validParams;

    public TokenHelper(IOptions<JwtSetting> setts)
    {
        _settings = setts.Value;
        _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

        _validParams = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _settings.Issuer,
            ValidAudience = _settings.Audience,
            IssuerSigningKey = _signingKey,
            ClockSkew = TimeSpan.Zero
        };
    }

    public string Generar(string usuario, string identificador, IEnumerable<string>? prfs = null)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.NameId, identificador),
            new(JwtRegisteredClaimNames.Name, usuario),
            new(ClaimTypes.Role, "user"),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()
                , ClaimValueTypes.Integer64)
        };
        if (prfs is not null)
            claims.AddRange(prfs.Select(r => new Claim(ClaimTypes.Role, r)));
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_settings.ExpireMinutes),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = new SigningCredentials(_signingKey
                , SecurityAlgorithms.HmacSha256)
        };
        SecurityToken tkn = _handler.CreateToken(descriptor);
        return _handler.WriteToken(tkn);
    }

    public ClaimsPrincipal? Validado(string token)
    {
        try
        {
            return _handler.ValidateToken(token, _validParams, out _);
        }
        catch (Exception)
        {
            return null;
        }
    }
}