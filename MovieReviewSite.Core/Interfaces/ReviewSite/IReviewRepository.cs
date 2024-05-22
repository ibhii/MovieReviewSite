using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Review;
using MovieReviewSite.Core.Models.Review.Request;
using MovieReviewSite.Core.Models.Review.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IReviewRepository : IBaseRepository
{
    Task<List<ReviewBase>> GetAllReviews();
    Task<List<ReviewPreview>> GetReviewsByMovieId(int id,ReviewListRequest dto);
    Task<ReviewDetails> GetReviewById(int id);
    Task LikeReview(int id);
    Task AddReview(AddReviewRequest dto,int id);
    Task UpdateReview(UpdateReviewRequest dto);
    Task DeleteReview(int id,int userId);
    Task<List<ReviewPreview>> GetReviewsListByUserId(int id);
    Task<double?> GetScoreAverageByMovieId(int id);

}
