﻿using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class MovieGenre
{
    public int Id { get; set; }

    public int? MovieId { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual Movie? Movie { get; set; }
}
