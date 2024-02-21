using Microsoft.Extensions.DependencyInjection;
using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Repositories.Genre;
using MovieReviewSite.Core.Repositories.Movie;
using MovieReviewSite.Core.Repositories.Review;

namespace MovieReviewSite.Core.Repositories.Base;

public class ServiceConfiguration : IServiceConfiguration
{
    public ServiceConfiguration(IServiceCollection services)
    {
        
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
    }
    
}
