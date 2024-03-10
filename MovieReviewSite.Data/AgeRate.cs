using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class AgeRate
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
