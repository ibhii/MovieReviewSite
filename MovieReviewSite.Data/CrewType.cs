using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class CrewType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsEnabled { get; set; }

    public virtual ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
}
