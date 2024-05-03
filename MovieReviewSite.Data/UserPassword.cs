using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class UserPassword
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PasswordId { get; set; }

    public virtual Password Password { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
