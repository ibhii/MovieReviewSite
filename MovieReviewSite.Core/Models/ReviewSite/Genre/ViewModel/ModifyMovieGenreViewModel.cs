using System.Reflection.Metadata.Ecma335;
using MovieReviewSite.Core.Models.Genre.Request;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Models.Genre.ViewModel;

public class ModifyMovieGenreViewModel
{
    public  MovieBase? Movie { get; set; }
    public List<GenreBase>? AllGenres { get; set; }
    public List<GenreBase>? MovieGenres  { get; set; }
    public MovieGenreRequest DTO { get; set; }
}
