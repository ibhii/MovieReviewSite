using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Services.Movie;

public partial class MovieBaseService :IMovieBaseService
{
    private readonly ReviewSiteContext _context;
    private IMovieBaseService _movieBaseServiceImplementation;

    public MovieBaseService(ReviewSiteContext context1, IMovieBaseService movieBaseServiceImplementation)
    {
        _context = context1;
        _movieBaseServiceImplementation = movieBaseServiceImplementation;
    }
}
