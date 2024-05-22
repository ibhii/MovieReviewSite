using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Models.Role;
using MovieReviewSite.Core.Models.User;
using Microsoft.AspNetCore.Authentication;
using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public async Task LoginUser(LoginUserRequest dto)
    {
        //check if the dto is empty or null
        if (dto.Password.IsNullOrEmpty() || dto.Username.IsNullOrEmpty())
        {
            throw new BadHttpRequestException("please enter a value for both username and password fields!");
        }

        var usernameExists = await AuthorizeUsername(dto.Username!);
        // var emailExists = await AuthorizeEmail(dto.Username!);

        //checks if username exists
        if (!usernameExists)
        {
            throw new BadHttpRequestException("the username you've entered is invalid!");
        }

        var user = await GetUserByUsername(dto.Username!);
        var isPasswordOk = await _passwordRepository.AuthorizeUserPassword(dto.Password!, user!.Id);
        //checks if password is correct
        if (!isPasswordOk)
        {
            throw new BadHttpRequestException("the password you've entered is invalid!");
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role!.Role!),
            new Claim(ClaimTypes.Name,user.UserName!),
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
    }

    public async Task<bool> AuthorizeUsername(string username)
    {
        return await _context.Users.AnyAsync(u => u.UserName != username);
    }

    public async Task<bool> AuthorizeEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email != email);
    }

    public async Task<int> GetUserIdByByUsername(string username)
    {
        return await _context.Users.Where(u => u.UserName == username || u.Email == username).Select(u => u.Id)
            .SingleOrDefaultAsync();
    }

    public async Task<BaseUserModel?> GetUserByUsername(string username)
    {
        return await _context.Users.Where(u => u.UserName == username || u.Email == username)
            .Select(u => new BaseUserModel()
            {
                Id = u.Id,
                UserName = u.UserName,
                Name = u.FullName,
                Role = new BaseRole()
                {
                    RoleCode = (int) u.RoleCode!,
                    Role = u.RoleCodeNavigation!.Title
                }
            }).SingleOrDefaultAsync();
    }
}
