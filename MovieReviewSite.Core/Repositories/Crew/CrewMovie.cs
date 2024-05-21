using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;
using MovieReviewSite.Core.Models.Crew;
using MovieReviewSite.Core.Models.Crew.Requests;
using MovieReviewSite.Core.Models.Crew.ResponseBase;
using MovieReviewSite.Core.Models.Crew.ViewModels;
using MovieReviewSite.Core.Models.Movie;
using MovieReviewSite.DataBase;

namespace MovieReviewSite.Core.Repositories.Crew;

public partial class CrewRepository
{
    public async Task<List<BaseCrewWithType>> GetCrewByMovieId(int id)
    {
        return await _context.MovieCrews.Where(mc => mc.MovieId == id)
            .Select(mc => new BaseCrewWithType()
            {
                Id = mc.CrewId,
                FullName = mc.Crew!.FullName,
                CrewType = new BaseIdTitleModel()
                {
                    Id = mc.CrewTypeCode,
                    Title = mc.CrewTypeCodeNavigation!.Title
                }
            }).ToListAsync();
    }

    public async Task AddCrewToMovie(CrewMovieRequest dto)
    {
        //checks to see id the crew already belongs to the movie or not
        var isCrewDuplicated = await IsCrewRelatedToMovie(dto);
        if (isCrewDuplicated)
        {
            throw new ArgumentException("this crew already belongs to this movie!");
        }

        //gets movie and crew by id
        var movie = await _movieRepository.GetMovieById(dto.MovieId);
        var crew = await GetCrewById(dto.CrewId);

        //checks to make sure that the movie and crew exist
        if (movie == null || crew == null)
        {
            throw new ArgumentException("this movie/crew does not exist!");
        }

        //adds the data
        var newMovieCrew = new MovieCrew()
        {
            MovieId = movie!.Id,
            CrewId = crew!.Id,
            CrewTypeCode = dto.CrewType
        };
        await _context.AddAsync(newMovieCrew);
        await _context.SaveChangesAsync();
        //updates movie's update time
        await _movieRepository.UpdateMovieLastModifiedOnById(dto.MovieId);
    }

    public async Task RemoveCrewFromMovie(CrewMovieRequest dto)
    {
        
        var isCrewInMovie = await IsCrewRelatedToMovie(dto);
        if (!isCrewInMovie)
        {
            throw new BadHttpRequestException("information is invalid!");
        }

        var movieCrew = await _context.MovieCrews.Where(mc =>
                mc.MovieId == dto.MovieId && mc.CrewId == dto.CrewId && mc.CrewTypeCode == dto.CrewType)
            .SingleOrDefaultAsync();
        _context.Remove(movieCrew!);
        await _context.SaveChangesAsync();
    }

    //checks to see id the crew already belongs to the movie or not
    private async Task<bool> IsCrewRelatedToMovie(CrewMovieRequest dto)
    {
        return await _context.MovieCrews.Where(mc => mc.MovieId == dto.MovieId)
            .AnyAsync(mc => mc.CrewId == dto.CrewId && mc.CrewTypeCode == dto.CrewType);
    }

    public async Task<MovieBase?> GetMovieById(int id)
    {
        return await _movieRepository.GetMovieById(id);
    }

    public async Task<BaseIdTitleModel?> GetCrewTypeByCrewIdAndMovieId(int movieId, int crewId)
    {
        return await _context.MovieCrews.Where(mc => mc.MovieId == movieId && mc.CrewId == crewId)
            .Select(mc => new BaseIdTitleModel()
            {
                Id = mc.CrewTypeCode,
                Title = mc.CrewTypeCodeNavigation!.Title
            })
            .SingleOrDefaultAsync();
    }
}
