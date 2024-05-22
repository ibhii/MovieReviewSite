using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class Password
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? HashPassword { get; set; }

    public string? Password1 { get; set; }

    public string? LastPassword { get; set; }

    public string? Salt { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserPassword> UserPasswords { get; set; } = new List<UserPassword>();
}
