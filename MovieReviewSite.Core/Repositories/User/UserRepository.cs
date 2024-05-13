using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Interfaces.Services;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.Core.Repositories.User.Extensions;
using MovieReviewSite.DataBase;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository : IUserRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IReviewRepository _reviewRepository;
    private readonly IPasswordRepository _passwordRepository;
    private readonly IAuthServices _authServices;

    public UserRepository(ReviewSiteContext context, IReviewRepository reviewRepository,
        IPasswordRepository passwordRepository, IAuthServices authServices)
    {
        _context = context;
        _reviewRepository = reviewRepository;
        _passwordRepository = passwordRepository;
        _authServices = authServices;
    }

    public async Task<List<BaseUserModel>> GetAllUsers(AllUsersListRequest dto)
    {
        return await _context.Users.Where(u => u.IsActive == true)
            .Search(dto.Search)
            .OrderByCreatedOn(dto.CreatedOnOrder)
            .FilterRole(dto.RoleFilter)
            .Select(u => new BaseUserModel()
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


    public async Task<BaseUserModel?> GetUserById(int id)
    {
        return await _context.Users.Where(u => u.Id == id).Select(u => new BaseUserModel()
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


    public async Task UpdateUser(int id, UpdateUserRequest dto)
    {
        var user = await _context.Users.Where(u => u.Id == id).SingleOrDefaultAsync();
        if (id != dto.ModifierId && dto.ModifierRoleCode != 1)
            throw new ArgumentException("this user is not authorized to preform this action");
        if (!dto.Username.IsNullOrEmpty())
        {
            var isUsernameUnique = await AuthorizeUsername(dto.Username!);

            if (!isUsernameUnique)
            {
                throw new ArgumentException("this user name already exists!");
            }
        }

        user!.LastModifiedOn = DateTime.UtcNow;
        user.UserName = dto.Username.IsNullOrEmpty() ? user.UserName : dto.Username;
        user.FirstName = dto.FirstName.IsNullOrEmpty() ? user.FirstName : dto.FirstName;
        user.LastName = dto.LastName.IsNullOrEmpty() ? user.LastName : dto.LastName;
        user.Email = dto.Email.IsNullOrEmpty() ? user.Email : dto.Email;
        user.BirthDate = dto.BirthDate == null ? user.BirthDate : dto.BirthDate;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

    }


    public async Task DeactivateUser(int id, BaseModifier modifier)
    {
        var user = await _context.Users.Where(u => u.Id == id).SingleOrDefaultAsync();

        if (user!.Id != modifier.Id || modifier.Id != 1 || modifier.Id != 2)
        {
            throw new ArgumentException("this user is not authorized to preform this action");
        }

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
