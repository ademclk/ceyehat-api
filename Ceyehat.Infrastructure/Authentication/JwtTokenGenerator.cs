using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Services;
using Ceyehat.Contracts.Authentication;
using Ceyehat.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Ceyehat.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public Token GenerateToken(User? user)
    {
        var token = new Token()
        {
            ExpireDate = DateTime.Now.AddMinutes(15)
        };
        var signingKey = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha512Signature);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingKey);

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        token.AccessToken = tokenHandler.WriteToken(securityToken);
        token.RefreshToken = CreateRefreshToken();

        return token;
    }

    private string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}