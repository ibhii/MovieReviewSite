using System.ComponentModel.DataAnnotations;
using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Movie.Responses;

public class Movies : MovieBase
{
    [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
    public DateTimeOffset? ReleaseDate { get; set; }
    public int? Duration { get; set; }
    public double? Score { get; set; }
    public BaseIdTitleModel? AgeRating { get; set; }
    public byte[]? Image { get; set; }
    public int ReviewsCount { get; set; }
}
