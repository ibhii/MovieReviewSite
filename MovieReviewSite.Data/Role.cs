using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Role
{
    public int Code { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVisible { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
