using Microsoft.EntityFrameworkCore;

namespace MovieReviewSite.Core.Repositories.Password;

public partial class PasswordRepository
{
    public async Task<bool> AuthorizeUserPassword(string password,int userId)
    {
        var usersPassword = await _context.Passwords.Where(p => p.UserId == userId)
            .OrderByDescending(p => p.Id).Select(p => p.HashPassword).FirstOrDefaultAsync();
        var hashedPassword = await HashPassword(password);
        return hashedPassword == usersPassword;
    }
}
