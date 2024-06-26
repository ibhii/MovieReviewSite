﻿namespace MovieReviewSite.Core.Models.Crew.Requests;

public class UpdateCrewRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateTime? BirthDate { get; set; }
    public int UserId { get; set; }
}
