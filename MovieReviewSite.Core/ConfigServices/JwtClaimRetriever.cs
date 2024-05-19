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
    
    public List<Claim> GetClaimsFromToken()
    {
        var token = GetAuthToken();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, // Set based on your configuration
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_signing_key")), // Replace with your key
            ValidateIssuer = true, // Set based on your configuration
            ValidIssuer = "your_issuer", // Replace with your issuer
            ValidateAudience = true, // Set based on your configuration
            ValidAudience = "your_audience", // Replace with your audience
            ValidateLifetime = true // Set based on your needs
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken validatedToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
        return principal.Claims.ToList();
    }
    
    public string? GetAuthToken()
    {
        var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
        return authorizationHeader?.ToString().Split(' ').FirstOrDefault()?.Trim(); // Extract token value
    }
}

