using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class ReviewScore
{
    public int Code { get; set; }

    public double? Value { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
