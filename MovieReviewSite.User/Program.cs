using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieReviewSite.Core.Enums;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Interfaces.Services;
using MovieReviewSite.Core.Repositories.Comment;
using MovieReviewSite.Core.Repositories.Crew;
using MovieReviewSite.Core.Repositories.Genre;
using MovieReviewSite.Core.Repositories.Movie;
using MovieReviewSite.Core.Repositories.Password;
using MovieReviewSite.Core.Repositories.Review;
using MovieReviewSite.Core.Repositories.Tag;
using MovieReviewSite.DataBase.Contexts;
using AuthServices = MovieReviewSite.Core.ConfigServices.AuthServices;
using UserRepository = MovieReviewSite.Core.Repositories.User.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ReviewSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICrewRepository, CrewRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

// Authentication Based On Cookie
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/User/LoginUser"; // Specify the login page URL
    });
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ReviewSiteContext>();

//handles authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("VipOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error ");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapIdentityApi<IdentityUser>();
app.UseCookiePolicy();


app.UseRouting();
//adding UseAuthentication
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=GetAllMoviesList}/{id?}");

app.Run();
