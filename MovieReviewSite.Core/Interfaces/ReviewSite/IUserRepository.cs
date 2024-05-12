using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Services;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.Core.Models.User.ViewModel;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IUserRepository : IBaseRepository
{
    Task<List<BaseUserModel>> GetAllUsers();
    Task<BaseUserModel?> GetUserById(int id);
    Task AddUser(NewUserRequest dto);
    Task UpdateUser(int id,UpdateUserRequest dto);
    Task DeactivateUser(int id,BaseModifier modifier);
    Task<LoginResponse> LoginUser(LoginUserRequest dto);
    Task ChangeUserRole(UserRole dto);
    Task<UserDetailsViewModel> GetUserDetails(int id);
    Task<bool> AuthorizeUsername(string username);
    Task<bool> AuthorizeEmail(string email);
    Task<int> GetUserIdByByUsername(string username);
    Task<BaseUserModel?> GetUserByUsername(string username);
    Task<int?> GetUserRoleCodeById(int id);
    Task<bool> IsUserAdminOrVIP(int id);
    Task<bool> IsUserAdmin(int id);
}
