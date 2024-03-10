using System.ComponentModel.DataAnnotations;
using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Genre;

namespace MovieReviewSite.Core.Models.Movie.Responses;

public class MovieDetail : Movies
{
    public string?  MovieName { get; set; }
    public string? Synopsis { get; set; }
    public List<CrewMovieModel>? Crew { get; set; }
    public List<GenreBase?> Genre { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
    public int Rating { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    public int? ReviewsCount { get; set; }
}
