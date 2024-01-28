using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Services.Movie;

public partial class MovieBaseService :IMovieBaseService
{
    private readonly ReviewSiteContext _context;

    public MovieBaseService(ReviewSiteContext context1, IMovieBaseService movieBaseServiceImplementation)
    {
        _context = context1;
    }
}
