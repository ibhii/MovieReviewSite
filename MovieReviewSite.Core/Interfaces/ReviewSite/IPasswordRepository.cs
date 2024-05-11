using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Password;
using MovieReviewSite.Core.Models.Password.Requests;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IPasswordRepository : IBaseRepository
{
    Task<string?> GetById(int id);
    Task<List<BasePassword>> GetPasswordsByUserId(int id);
    Task<BasePassword?> GetUsersCurrentPassword(int id);
    Task<BasePassword?> GetUsersLastPassword(int id);
    Task ChangePassword(UpdatePasswordRequest dto);
    Task<bool> AuthorizeUserPassword(string password, int userId);
}
