﻿using Microsoft.EntityFrameworkCore;

namespace MovieReviewSite.Core.Repositories.User;

public partial class UserRepository
{
    public async Task<int?> GetUserRoleCodeById(int id)
    {
        return await _context.Users.Where(u => u.Id == id).Select(u => u.RoleCode).SingleOrDefaultAsync();
    }

    public async Task<bool> IsUserAdminOrVIP(int id)
    {
        var userRole = await GetUserRoleCodeById(id);
        if(userRole == 2)
        {
            throw new ArgumentException("UserIs not Authorized to preform this action!(user must be admin or vip member)");
        }

        return true;
    }
    
    public async Task<bool> IsUserAdmin(int id)
    {
        var userRole = await GetUserRoleCodeById(id);
        if(userRole == 2 || userRole == 3)
        {
            throw new ArgumentException("UserIs not Authorized to preform this action!(user must be admin)");
        }

        return true;
    }
}