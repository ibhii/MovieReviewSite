using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public UserAuth UserAuth { get; set; }

    public async Task UpdateUserAuthInfoAfterLogin(UserAuth userinfo)
    {
        UserAuth = userinfo;
    }
    
    public async Task<UserAuth> GetUserAuthInfo()
    {
        return UserAuth;
    }

}
