using Microsoft.Extensions.DependencyInjection;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Interfaces.Services;

public interface IAuthServices
{
    void ConfigureServices(IServiceCollection services);
    string GenerateJsonWebToken(BaseUserModel userModelInfo);

}
