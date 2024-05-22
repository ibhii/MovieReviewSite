namespace MovieReviewSite.Core.Repositories.Crew.Extensions;

public static class MovieListForCrewExtension
{
    public static IQueryable<DataBase.MovieCrew> Search(this IQueryable<DataBase.MovieCrew> source, string? searchTerm)
    {
        return string.IsNullOrEmpty(searchTerm) ? source : // No search term, return original query
            source.Where(mc => mc.Movie!.Name!.Contains(searchTerm));
    }
}
