﻿using System;
using System.Collections.Generic;

namespace MovieReviewSite.DataBase;

public partial class User
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? FullName { get; set; }

    public int? PasswordId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public int Id { get; set; }

    public int? RoleCode { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool? IsVisible { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public bool? IsEmailConfirmed { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public DateTime? LockOutEnd { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Crew> Crews { get; set; } = new List<Crew>();

    public virtual ICollection<Password> Passwords { get; set; } = new List<Password>();

    public virtual ICollection<ReviewTag> ReviewTags { get; set; } = new List<ReviewTag>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role? RoleCodeNavigation { get; set; }
}