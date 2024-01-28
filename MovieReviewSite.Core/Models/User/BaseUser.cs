using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.User;

public class BaseUser
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public int? RoleCode { get; set; }
}
