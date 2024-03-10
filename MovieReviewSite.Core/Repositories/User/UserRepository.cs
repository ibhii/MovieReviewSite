using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository : IUserRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IReviewRepository _reviewRepository;

    public UserRepository(ReviewSiteContext context, IReviewRepository reviewRepository)
    {
        _context = context;
        _reviewRepository = reviewRepository;
    }

    public async Task<List<BaseUser>> GetAllUsers()
    {
        return await _context.Users.Select(u => new BaseUser()
        {
            Id = u.Id,
            Name = u.FullName,
            UserName = u.UserName,
            Role = new BaseRole()
            {
                RoleCode = u.RoleCodeNavigation!.Code,
                Role = u.RoleCodeNavigation.Title
            },
        }).ToListAsync();
    }


    public async Task<BaseUser?> GetUserById(int id)
    {
        return await _context.Users.Where(u => u.Id == id).Select(u => new BaseUser()
        {
            Id = u.Id,
            Name = u.FullName,
            UserName = u.UserName,
            Role = new BaseRole()
            {
                RoleCode = u.RoleCodeNavigation!.Code,
                Role = u.RoleCodeNavigation.Title
            },
        }).SingleOrDefaultAsync();
    }

    public async Task AddUser(NewUserRequest dto)
    {
        var user = new DataBase.User()
        {
            UserName = dto.UserName,
            RoleCode = 2,
            // PasswordId = 
        };
    }

    public async Task UpdateAddUserDetails(UpdateUserRequest dto)
    {
        var user = await _context.Users.Where(u => u.Id == dto.Id).SingleOrDefaultAsync();
        user!.LastModifiedOn = DateTime.UtcNow;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.IsActive = true;
        user.IsVisible = true;
        user.IsEmailConfirmed = false;
        user.BirthDate = dto.BirthDate;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
        _context.Users.Remove(user!);
        await _context.SaveChangesAsync();
    }

    public async Task ChangeUserRole(UserRole dto)
    {
        var user = await _context.Users.Where(u => u.Id == dto.UserId).SingleOrDefaultAsync();
        user!.RoleCode = dto.RoleCode;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
