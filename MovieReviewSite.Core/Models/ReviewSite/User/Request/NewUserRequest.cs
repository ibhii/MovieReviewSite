﻿using System.Security.Cryptography;

namespace MovieReviewSite.Core.Models.User.Request;

public class NewUserRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
