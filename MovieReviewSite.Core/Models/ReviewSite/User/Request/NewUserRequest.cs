using System.Security.Cryptography;

namespace MovieReviewSite.Core.Models.User.Request;

public class NewUserRequest
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
