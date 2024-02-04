using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Services.Movie;

public partial class MovieService : IMovieService
{
    private readonly ReviewSiteContext _context;
    private readonly IMovieService _service;

    public MovieService(ReviewSiteContext context1, IMovieService service)
    {
        _service = service;
        _context = context1;
    }
}
