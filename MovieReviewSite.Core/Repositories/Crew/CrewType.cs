using Microsoft.EntityFrameworkCore;
using MovieReviewSite.Core.Models;

namespace MovieReviewSite.Core.Repositories.Crew;

public partial class CrewRepository
{
    public async Task<List<BaseIdTitleModel>> GetCrewTypes()
    {
        return await _context.CrewTypes.Select(ct => new BaseIdTitleModel()
        {
            Id = ct.Id,
            Title = ct.Title
        }).ToListAsync();
    }
}
