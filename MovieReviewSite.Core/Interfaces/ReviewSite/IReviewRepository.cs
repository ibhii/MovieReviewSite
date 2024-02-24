using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IReviewRepository : IBaseRepository
{
    Task<List<ReviewBase>> GetAllReviews();
    Task<List<ReviewPreview>> GetReviewsByMovieId(int id);
    Task<ReviewDetails> GetReviewById(int id);
    Task LikeReview(int id);
    Task AddReview(AddReviewRequest dto);
    Task UpdateReview(UpdateReviewRequest dto);
    Task DeleteReview(int id);

}
