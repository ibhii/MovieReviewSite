using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Interfaces.Services;

public interface IAuthServices
{
    string GenerateJsonWebToken(IEnumerable<Claim> claims);
    List<Claim> GetClaimsFromToken();
    public void ConfigureServices(IServiceCollection services);
}
