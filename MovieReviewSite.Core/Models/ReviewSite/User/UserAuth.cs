using System.Reflection.Metadata.Ecma335;

namespace MovieReviewSite.Core.Models.User;

public class UserAuth : BaseModel
{
    public int RoleCode { get; set; }
    public string? Username { get; set; }
    public bool IsLoggedIn { get; set; } = false;
}
