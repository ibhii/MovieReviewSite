using Microsoft.Extensions.DependencyInjection;
using MovieReviewSite.Core.Interfaces.Base;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Repositories.Comment;
using MovieReviewSite.Core.Repositories.Crew;
using MovieReviewSite.Core.Repositories.Genre;
using MovieReviewSite.Core.Repositories.Movie;
using MovieReviewSite.Core.Repositories.Review;
using MovieReviewSite.Core.Repositories.Tag;
using MovieReviewSite.Core.Repositories.User;

namespace MovieReviewSite.Core.Repositories.Base;

public class ServiceConfiguration : IServiceConfiguration
{
    public ServiceConfiguration(IServiceCollection services)
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICrewRepository, CrewRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}
