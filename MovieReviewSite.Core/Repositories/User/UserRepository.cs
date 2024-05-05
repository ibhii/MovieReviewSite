using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.DataBase;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository : IUserRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IReviewRepository _reviewRepository;
    private readonly IPasswordRepository _passwordRepository;

    public UserRepository(ReviewSiteContext context, IReviewRepository reviewRepository, IPasswordRepository passwordRepository)
    {
        _context = context;
        _reviewRepository = reviewRepository;
        _passwordRepository = passwordRepository;
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

    

    public async Task UpdateUser(UpdateUserRequest dto)
    {
        var user = await _context.Users.Where(u => u.Id == dto.Id).SingleOrDefaultAsync();
        user!.LastModifiedOn = DateTime.UtcNow;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.IsActive = true;
        user.IsVisible = true;
        user.BirthDate = dto.BirthDate;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeactivateUser(int id)
    {
        var user = await _context.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
        
        //checks if user is not admin
        if (user!.RoleCode != 1)
        {
            user!.IsActive = false;
            _context.Users.Update(user);
        }
        else
        {
            throw new ArgumentException("the user is an Admin and cant be deactivated");
        }
        await _context.SaveChangesAsync();
    }

    private async Task<bool> DoesUsernameExist(string username)
    {
        return await _context.Users.AnyAsync(u => u.UserName == username);
    }
    
    private async Task<bool> DoesEmailExist(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
