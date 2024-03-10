using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class ReviewTag
{
    public int Id { get; set; }

    public int? ReviewId { get; set; }

    public int? TagId { get; set; }

    public virtual Review? Review { get; set; }

    public virtual Tag? Tag { get; set; }
}
