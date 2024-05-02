using System.ComponentModel;
using MovieReviewSite.Core.Models.Movie.Request;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Models.Movie.ViewModels;

public class AllMoviesListVewModel
{
    public List<Movies>? Movie { get; set; }
    public MovieListRequest DTO { get; set; }
}
