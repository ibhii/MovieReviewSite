using Microsoft.AspNetCore.Identity;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Models.Services;

public class LoginResponse
{
    public string? Token { get; set; }
    public BaseUser? User { get; set; }
}
