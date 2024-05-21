using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Interfaces.Services;

namespace MovieReviewSite.Core.ConfigServices;

public partial class AuthServices : IAuthServices
{
    private readonly IConfiguration _config;
    private readonly string? _secretKey; // Assuming you have retrieved the key securely

    public AuthServices(IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        _config = config;
        _httpContextAccessor = httpContextAccessor;
        _secretKey = config["Security:SecretKey"]; // Or retrieve it from a secure source
    }

    public string GenerateJsonWebToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims : claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string?> ValidateToken(string tokenString)
    {
        try
        {
            // Use a JWT library to validate the token signature and expiration
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"])),
                ValidateIssuer = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _config["Jwt:Audience"],
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ValidateToken(tokenString, tokenValidationParameters,
                out SecurityToken validatedToken);

            // Get ClaimsPrincipal using a compatible approach
            string claimsPrincipal = null;
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                claimsPrincipal = jwtSecurityToken.Subject;  // Use Subject property for ClaimsPrincipal in newer versions
            }
            return claimsPrincipal;
        
        }
        catch (Exception)
        {
            // Handle invalid token scenario (e.g., redirect to login)
            return null;
        }
    }
}
