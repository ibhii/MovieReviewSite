using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Password;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Password;

public partial class PasswordRepository : IPasswordRepository
{
    private readonly ReviewSiteContext _context;

    public PasswordRepository(ReviewSiteContext context)
    {
        _context = context;
    }

    public async Task<string?> GetById(int id)
    {
        return await _context.Passwords.Where(p => p.Id == id).Select(p => p.Password1).SingleOrDefaultAsync();
    }

    public async Task<List<BasePassword>> GetPasswordsByUserId(int id)
    {
        return await _context.Passwords.Where(p => p.UserId == id).Select(p => new BasePassword()
        {
            Id = p.Id,
            Password = p.Password1
        }).ToListAsync();
    }

    public async Task<BasePassword?> GetUsersCurrentPassword(int id)
    {
        return await _context.Passwords.OrderByDescending(p => p.Id).Select(p => new BasePassword()
        {
            Id = p.Id,
            Password = p.Password1
        }).FirstOrDefaultAsync();
    }

    public async Task<BasePassword?> GetUsersLastPassword(int id)
    {
        var userPasswords = await GetPasswordsByUserId(id);

        //order the list by id
        var orderedList = userPasswords.OrderByDescending(up => up.Id).ToList();
        
        //choosing the second to last element in the list 
        var lastPassword = orderedList[1];
        return lastPassword;
    }
}
