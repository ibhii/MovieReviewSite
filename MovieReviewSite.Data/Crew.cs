using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Crew
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool? IsAlive { get; set; }

    public DateTime? DeathDate { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsActive { get; set; }

    public string CompleteFullName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
}
