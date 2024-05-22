namespace MovieReviewSite.Core.Repositories.Review.Extensions;

public static class ReviewListByMovieIdExtensions
{
    public static IQueryable<DataBase.Review> Search(this IQueryable<DataBase.Review> source, string? searchTerm)
    {
        return string.IsNullOrEmpty(searchTerm) ? source : // No search term, return original query
            source.Where(r => r.Author!.UserName!.Contains(searchTerm) || r.Title!.Contains(searchTerm) || r.Review1!.Contains(searchTerm));
    }

}
