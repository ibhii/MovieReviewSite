using MovieReviewSite.Core.Interfaces.Movie;
using MovieReviewSite.Core.Services.Movie;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddKeyedSingleton<IMovieService, MovieService >("movie");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Movie",
    pattern: "{controller=Movie}/{action=GetMovieDetail}/{id}");
app.MapControllerRoute(
    name: "Movie",
    pattern: "{controller=Movie}/{action=GetMoviesList}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
