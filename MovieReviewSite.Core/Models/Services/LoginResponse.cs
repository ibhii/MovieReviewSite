using Microsoft.AspNetCore.Identity;

namespace MovieReviewSite.Core.Models.Services;

public class LoginResponse
{
    public string? Token { get; set; }
}
