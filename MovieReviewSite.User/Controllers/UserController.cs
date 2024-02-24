using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;

namespace MovieReviewSite.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<List<BaseUser>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    [HttpGet("[action]")]
    public async Task<BaseUser?> GetUserById([FromQuery]int id)
    {
        return await _userRepository.GetUserById(id);
    }

    [HttpPost("[action]")]
    public async Task AddUser([FromBody]NewUserRequest dto)
    {
        await _userRepository.AddUser(dto);
    }

    [HttpPut("[action]")]
    public async Task UpdateAddUserDetails([FromBody]UpdateUserRequest dto)
    {
        await _userRepository.UpdateAddUserDetails(dto);
    }

    [HttpDelete("[action]")]
    public async Task DeleteUser([FromBody]int id)
    {
        await _userRepository.DeleteUser(id);
    }

    /// <summary>
    /// changes a users role
    /// </summary>
    /// <param name="dto"></param>
    [HttpPut("[action]")]
    public async Task ChangeUserRole([FromBody]UserRole dto)
    {
        await _userRepository.ChangeUserRole(dto);
    }
}
