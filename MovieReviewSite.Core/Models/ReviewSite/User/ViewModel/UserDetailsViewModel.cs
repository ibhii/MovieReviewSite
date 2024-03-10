using MovieReviewSite.Core.Models.Review.Responses;
using MovieReviewSite.Core.Models.User.Response;

namespace MovieReviewSite.Core.Models.User.ViewModel;

public class UserDetailsViewModel
{
    public UserDetails? UserBaseInfo { get; set; }
    public List<ReviewPreview> UserReviews  { get; set; }
    
}
