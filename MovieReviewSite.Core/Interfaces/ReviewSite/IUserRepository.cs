using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.Core.Models.User.ViewModel;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IUserRepository : IBaseRepository
{
    Task<List<BaseUser>> GetAllUsers();
    Task<BaseUser?> GetUserById(int id);
    Task AddUser(NewUserRequest dto);
    Task UpdateAddUserDetails(UpdateUserRequest dto);
    Task DeleteUser(int id);
    Task ChangeUserRole(UserRole dto);
    Task<UserDetailsViewModel> GetUserDetails(int id);
}
