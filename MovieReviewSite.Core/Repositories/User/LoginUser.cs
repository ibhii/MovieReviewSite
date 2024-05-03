using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public async Task<bool> LoginUser(LoginUserRequest dto)
    {
        //check if the dto is empty or null
        if (dto.Password.IsNullOrEmpty() || dto.Username.IsNullOrEmpty())
        {
            throw new ArgumentException("please enter a value for both username and password fields!");
        }
        var userExists = await AuthorizeUsername(dto.Username!);
        //checks if username exists
        if (!userExists)
        {
            throw new ArgumentException("the username you've entered is invalid!");
        }
        var user = await GetUserIdByByUsername(dto.Username!);
        var isPasswordOk = await _passwordRepository.AuthorizeUserPassword(dto.Password!, user);
        //checks if password is correct
        if (!isPasswordOk)
        {
            throw new ArgumentException("the password you've entered is invalid!");
        }
        return true;
    }

    public async Task<bool> AuthorizeUsername(string username)
    {
        return await _context.Users.AnyAsync(u => u.UserName == username);
    }
    
    public async Task<int> GetUserIdByByUsername(string username)
    {
        return await _context.Users.Where(u => u.UserName == username).Select(u => u.Id).SingleOrDefaultAsync();
    }
}
