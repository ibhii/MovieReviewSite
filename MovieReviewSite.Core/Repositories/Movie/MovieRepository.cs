using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository : IMovieRepository
{
    private readonly ReviewSiteContext _context;

    public MovieRepository(ReviewSiteContext context) 
    {
        _context = context;
    }
}
