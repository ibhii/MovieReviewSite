using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MovieReviewSite.Core.ConfigServices;

public partial class AuthServices
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthServices(IHttpContextAccessor httpContextAccessor, IConfiguration config)
    {
        _httpContextAccessor = httpContextAccessor;
        _config = config;
    }
    
    public IEnumerable<Claim> GetClaimsFromToken()
    {
        var token = GetAuthToken();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, // Set based on your configuration
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)), // Replace with your key
            ValidateIssuer = true, // Set based on your configuration
            ValidIssuer = _config["Jwt:Issuer"], // Replace with your issuer
            ValidateAudience = true, // Set based on your configuration
            ValidAudience = _config["Jwt:Issuer"], // Replace with your audience
            ValidateLifetime = true // Set based on your needs
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken validatedToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
        return principal.Claims.ToList();
    }

    public string? GetAuthToken()
    {
        var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Cookies["AuthorizationToken"];
        return authorizationHeader?.ToString().Split(' ').FirstOrDefault()?.Trim(); // Extract token value
    }
}

