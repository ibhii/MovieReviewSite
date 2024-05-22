using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.User;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public UserAuth UserAuth { get; set; }

    public async Task UpdateUserAuthInfoAfterLogin(UserAuth userinfo)
    {
        UserAuth = userinfo;
    }
    
    public async Task GetUserAuthInfo(int id)
    {
        var passwords = await _context.UserPasswords.Where(up => up.UserId == id).Select(us => us.Password).ToListAsync();
        foreach (var password in passwords)
        {
            password.HashPassword = await _passwordRepository.HashPassword(password.Password1!);
            _context.Update(password);
            await _context.SaveChangesAsync();
        }
        
        
        
    }

}
