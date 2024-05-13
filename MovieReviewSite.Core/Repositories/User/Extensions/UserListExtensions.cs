using MovieReviewSite.Core.Enums;

namespace MovieReviewSite.Core.Repositories.User.Extensions;

public static class UserListExtensions
{
    public static IQueryable<DataBase.User> Search(this IQueryable<DataBase.User> source, string? searchTerm)
    {
        return string.IsNullOrEmpty(searchTerm) ? source : // No search term, return original query
            source.Where(u => u.FullName!.Contains(searchTerm));
    }
    
    public static IQueryable<DataBase.User> OrderByCreatedOn(this IQueryable<DataBase.User> source, CreatedOnOrder? order)
    {
        var result = order switch
        {
            0 or null => source,
            CreatedOnOrder.CreatedOnAsc => source.OrderBy(u => u.CreatedOn),
            CreatedOnOrder.CreatedOnDes => source.OrderByDescending(u => u.CreatedOn),
            _ => source
        };
        return result;
    }
    
    public static IQueryable<DataBase.User> FilterRole(this IQueryable<DataBase.User> source, Roles? role)
    {
        var result = role switch
        {
            0 or null => source,
            Roles.Admin => source.Where(u => u.RoleCode == 1),
            Roles.Member => source.Where(u => u.RoleCode == 2),
            Roles.Vip => source.Where(u => u.RoleCode == 3),
            Roles.SecondaryAdmin => source.Where(u => u.RoleCode == 4),
            _ => source
        };
        return result;
    }
}
