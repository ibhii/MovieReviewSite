using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public async Task ChangeUserRole(UserRole dto)
    {
        if (dto.ModifierRoleCode != 1 || dto.ModifierRoleCode != 4)
        {
            throw new ArgumentException("user is not authorized to make these changes!");
        }
        var user = await Queryable.Where<DataBase.User>(_context.Users, u => u.Id == dto.UserId).SingleOrDefaultAsync();
        user!.RoleCode = dto.RoleCode;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
