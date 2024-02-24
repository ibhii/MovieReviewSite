using System.Reflection.Metadata.Ecma335;
using Microsoft.SqlServer.Server;
using MovieReviewSite.Core.Interfaces.Base;

namespace MovieReviewSite.Core.Models.Review.Request;

public class UpdateReviewRequest : IBaseModel
{
    public int Id { get; set; }
    public string? Review { get; set; }
    public string? Title { get; set; }
    public int GivenRate { get; set; }
}
