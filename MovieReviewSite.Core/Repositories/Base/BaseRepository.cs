using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Base;

public class BaseRepository : IBaseRepository 
{
    public readonly ReviewSiteContext _context;

    public BaseRepository(ReviewSiteContext context,DbContextOptions options) : base()
    {
        _context = context;
    }
    
}
