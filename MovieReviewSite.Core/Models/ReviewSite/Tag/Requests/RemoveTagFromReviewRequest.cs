using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MovieReviewSite.Core.Models.Tag.Requests;

public class RemoveTagFromReviewRequest
{
    public int ReviewId { get; set; }
    public List<int>? TagIds { get; set; }
}
