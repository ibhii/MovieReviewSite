﻿using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Genre;
using MovieReviewSite.Core.Models.Genre.Request;
using MovieReviewSite.Core.Models.Genre.Response;
using MovieReviewSite.Core.Models.Movie.Responses;

namespace MovieReviewSite.Core.Interfaces.ReviewSite;

public interface IGenreRepository : IBaseRepository
{
    Task<GenreBase> GetGenre(int id);
    Task<List<GenreBase>> GetGenreList();
    Task AddGenre(GenreBase genre);
    Task UpdateGenre(int id, GenreBase genre);
    Task DeleteGenre(int id);
    Task<List<GenreBase>> GetGenreByMovieId(int id);
    Task AddGenreByMovieId(MovieGenreRequest dto);
    Task RemoveGenreByMovieId(MovieGenreRequest dto);
    Task<GenreMovies?> GetMoviesByGenreId(int id);

}
