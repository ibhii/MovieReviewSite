using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Models.Review.ViewModels;

public class UpdateReviewViewModel 
{
    public ReviewDetails? Review { get; set; }
    public UpdateReviewRequest? DTO { get; set; }
    
}
