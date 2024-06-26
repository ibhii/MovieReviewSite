﻿using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Models.Movie.Responses;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Movie.Extensions;

public static class MovieListExtensions
{
    public static IQueryable<DataBase.Movie> Search(this IQueryable<DataBase.Movie> source, string? searchTerm)
    {
        return string.IsNullOrEmpty(searchTerm) ? source : // No search term, return original query
            source.Where(m => m.Name!.Contains(searchTerm) || m.MovieCrews.Any(mc => mc.Crew!.FullName.Contains(searchTerm)));
    }
    
    public static IQueryable<DataBase.Movie> OrderByReleaseDate(this IQueryable<DataBase.Movie> source, ReleasedOnOrder? order)
    {
        var result = order switch
        {
            0 or null => source,
            ReleasedOnOrder.ReleasedOnAsc => source.OrderBy(u => u.RealeaseDate),
            ReleasedOnOrder.ReleasedOnDesc => source.OrderByDescending(u => u.RealeaseDate),
            _ => source
        };
        return result;
    }
    
}
