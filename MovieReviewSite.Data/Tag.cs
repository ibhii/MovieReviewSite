using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Tag
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<ReviewTag> ReviewTags { get; set; } = new List<ReviewTag>();
}
