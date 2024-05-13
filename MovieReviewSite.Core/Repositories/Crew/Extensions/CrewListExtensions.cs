namespace MovieReviewSite.Core.Repositories.Crew.Extensions;

public static class CrewListExtensions
{
    public static IQueryable<DataBase.Crew> Search(this IQueryable<DataBase.Crew> source, string? searchTerm)
    {
        return string.IsNullOrEmpty(searchTerm) ? source : // No search term, return original query
            source.Where(c => c.FullName!.Contains(searchTerm));
    }
}
