﻿using Microsoft.EntityFrameworkCore; 
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Repositories.Review;
using MovieReviewSite.DataBase.Contexts;

namespace MovieReviewSite.Core.Repositories.Genre;

public partial class GenreRepository : IGenreRepository
{
    private readonly ReviewSiteContext _context;
    private readonly IMovieRepository _movieRepository;
    private readonly IReviewRepository _reviewRepository;

    public GenreRepository(ReviewSiteContext context, IMovieRepository movieRepository, IReviewRepository reviewRepository)
    {
        _context = context;
        _movieRepository = movieRepository;
        _reviewRepository = reviewRepository;
    }

    public async Task<GenreBase> GetGenre(int id)
    {
        var genre = await _context.Genres.Where(g => g.Id == id).SingleOrDefaultAsync();
        return new GenreBase()
        {
            Id = genre!.Id,
            Title = genre.Title,
        };
    }


    public async Task<List<GenreBase>> GetGenreList()
    {
        return await _context.Genres.Select(g => new GenreBase
        {
            Id = g.Id,
            Title = g.Title,
        }).ToListAsync();
    }

    public async Task AddGenre(GenreBase genre)
    {
        var addedGenre = new DataBase.Genre
        {
            Title = genre.Title,
        };
        await _context.Genres.AddAsync(addedGenre);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGenre(int id, GenreBase genre)
    {
        var updatedGenre = await _context.Genres.Where(g => g.Id == id).SingleOrDefaultAsync();
        if (updatedGenre != null)
        {
            updatedGenre.Title = genre.Title;
            _context.Update(updatedGenre);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteGenre(int id)
    {
        var genre = await _context.Genres.Where(g => g.Id == id).SingleOrDefaultAsync();
        if (genre != null)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
