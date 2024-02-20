using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Models.Genre;

namespace MovieReviewSite.Core.Interfaces.Genre;

public interface IGenreRepository : IBaseRepository
{
    Task<GenreBase> GetGenre(int id);
    Task<List<GenreBase>> GetGenreList();
    Task AddGenre(GenreBase genre);
    Task UpdateGenre(int id, GenreBase genre);
    Task DeleteGenre(int id);
    
}
