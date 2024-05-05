using Microsoft.EntityFrameworkCore;

namespace MovieReviewSite.Core.Repositories.Movie;

public partial class MovieRepository
{
    //updates a movies last modified date
    public async Task UpdateMovieLastModifiedOnById(int id)
    {
        var movie = await GetById(id);
        if (movie == null)
        {
            throw new ArgumentException("this movie does not exist!(cant update LastModifiedDate)");
        }
        movie!.LastModifiedOn = DateTime.UtcNow;

        _context.Update(movie);
        await _context.SaveChangesAsync();
    }
    
}
