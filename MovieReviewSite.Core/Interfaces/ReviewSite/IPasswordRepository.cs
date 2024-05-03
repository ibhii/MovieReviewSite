using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Password;
using MovieReviewSite.Core.Models.Password.Requests;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IPasswordRepository
{
    Task<string?> GetById(int id);
    Task<List<BasePassword>> GetPasswordsByUserId(int id);
    Task<BasePassword?> GetUsersCurrentPassword(int id);
    Task<BasePassword?> GetUsersLastPassword(int id);
    Task ChangePassword(UpdatePasswordRequest dto);
    Task<bool> AuthorizeUserPassword(string password, int userId);
}
