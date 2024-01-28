﻿using MovieReviewSite.Core.Models.Review;

namespace MovieReviewSite.Core.Models.Movie;

public class MovieDetail
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string?  MovieName { get; set; }
    public string? Synopsis { get; set; }
    public List<string>? Crew { get; set; }
    public List<string>? Genre { get; set; }
    public DateTimeOffset ReleaseDate { get; set; }
    public int Rating { get; set; }
    public int Duration { get; set; }
    public ReviewList? ReviewList { get; set; }
}
