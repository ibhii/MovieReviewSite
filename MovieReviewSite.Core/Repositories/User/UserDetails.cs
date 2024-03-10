using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User.Response;
using MovieReviewSite.Core.Models.User.ViewModel;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public async Task<UserDetailsViewModel> GetUserDetails(int id)
    {
        var user = await _context.Users.Where(u => u.Id == id).Select(u => new UserDetails()
        {
            Id = u.Id,
            Name = u.FullName,
            UserName = u.UserName,
            Role = new BaseRole()
            {
                RoleCode = u.RoleCodeNavigation!.Code,
                Role = u.RoleCodeNavigation.Title
            },
            Email = u.Email,
            CreatedOn = u.CreatedOn,
            LastModifiedOn = u.LastModifiedOn,
        }).SingleOrDefaultAsync();
        var userReviews = await _reviewRepository.GetReviewsListByUserId(id);
        var userDetails = new UserDetailsViewModel()
        {
            UserBaseInfo = user,
            UserReviews = userReviews
        };
        return userDetails;
    }

}
