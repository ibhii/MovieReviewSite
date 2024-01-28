using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Comment
{
    public int Id { get; set; }

    public string? Comment1 { get; set; }

    public int? AuthorId { get; set; }

    public int? ReviewId { get; set; }

    public virtual User? Author { get; set; }

    public virtual Review? Review { get; set; }
}
