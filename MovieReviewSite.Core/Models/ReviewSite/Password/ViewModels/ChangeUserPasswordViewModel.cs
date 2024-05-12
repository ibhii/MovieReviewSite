using MovieReviewSite.Core.Models.Password.Requests;
using MovieReviewSite.Core.Models.Password.Responses;

namespace MovieReviewSite.Core.Models.Password.ViewModels;

public class ChangeUserPasswordViewModel
{
    public PasswordForUser? Password { get; set; }
    public UpdatePasswordRequest? DTO { get; set; }
}
