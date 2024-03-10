using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class MovieCrew
{
    public int Id { get; set; }

    public int? CrewId { get; set; }

    public int? MovieId { get; set; }

    public int? CrewTypeCode { get; set; }

    public virtual Crew? Crew { get; set; }

    public virtual CrewType? CrewTypeCodeNavigation { get; set; }

    public virtual Movie? Movie { get; set; }
}
