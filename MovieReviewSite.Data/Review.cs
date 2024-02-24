using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Review
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int? ScoreCode { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Title { get; set; }

    public string? Review1 { get; set; }

    public int? LikesCount { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public virtual User? Author { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<ReviewTag> ReviewTags { get; set; } = new List<ReviewTag>();

    public virtual ReviewScore? ScoreCodeNavigation { get; set; }
}
