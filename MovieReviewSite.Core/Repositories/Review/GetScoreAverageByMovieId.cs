using Microsoft.EntityFrameworkCore;

namespace MovieReviewSite.Core.Repositories.Review;

public partial class ReviewRepository
{
    public async Task<double?> GetScoreAverageByMovieId(int id)
    {
        var movieScores = await _context.Reviews.Where(r => r.MovieId == id)
            .Select(r => r.ScoreCodeNavigation!.Value).ToListAsync();
        var sum = movieScores.Aggregate<double?, double?>(0.0, (current, score) => score + current);
        var result = sum / movieScores.Count;
        return Math.Round((double)result,1);
    }
}
