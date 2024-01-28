using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class MovieStatus
{
    public int Id { get; set; }

    public int? Code { get; set; }

    public string? Title { get; set; }
}
