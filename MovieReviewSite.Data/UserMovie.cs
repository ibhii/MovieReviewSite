using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class UserMovie
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public bool? IsWatched { get; set; }

    public bool? IsWantToWatch { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
