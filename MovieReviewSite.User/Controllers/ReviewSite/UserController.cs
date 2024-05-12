﻿using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Services;
using MovieReviewSite.Core.Models.User;
using MovieReviewSite.Core.Models.User.Request;
using MovieReviewSite.Core.Models.User.ViewModel;

namespace MovieReviewSite.Controllers.ReviewSite;

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
    public async Task<List<BaseUserModel>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    [HttpGet("[action]")]
    public async Task<BaseUserModel?> GetUserById([FromQuery] int id)
    {
        return await _userRepository.GetUserById(id);
    }

    [HttpPost("[action]")]
    public async Task AddUser([FromBody] NewUserRequest dto)
    {
        await _userRepository.AddUser(dto);
    }

    [HttpPost("[action]/{id}")]
    public async Task UpdateUser(int id,[FromBody] UpdateUserRequest dto)
    {
        await _userRepository.UpdateUser(id,dto);
    }

    [HttpPost("[action]/{id}")]
    public async Task DeactivateUser(int id,[FromBody]BaseModifier modifier)
    {
        await _userRepository.DeactivateUser(id,modifier);
    }

    /// <summary>
    /// changes a users role
    /// </summary>
    /// <param name="dto"></param>
    [HttpPut("[action]")]
    public async Task ChangeUserRole([FromBody] UserRole dto)
    {
        await _userRepository.ChangeUserRole(dto);
    }

    /// <summary>
    /// checks if entered information is correct then logs user in
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<LoginResponse> LoginUser([FromBody] LoginUserRequest dto)
    {
        return await _userRepository.LoginUser(dto);
    }

    /// <summary>
    /// returns a view with the list of all users 
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> GetAllUsersView()
    {
        var users= await _userRepository.GetAllUsers();
        return View(users);
    }

    /// <summary>
    /// returns view with users details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetUserDetailView(int id)
    {
        var userDetails = await _userRepository.GetUserDetails(id);
        return View(userDetails);
    }
    
    /// <summary>
    /// returns a view that updates user details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> GetUserUpdateView(int id)
    {
        var userDetails = await _userRepository.GetUserDetails(id);
        var result = new UpdateUserViewModel()
        {
            User = userDetails.UserBaseInfo!
        };
        return View(result);
    }

    /// <summary>
    /// returns view for users to sign in
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> LoginView()
    {
        var dto = new LoginUserRequest();
        return View(dto);
    }
    
    /// <summary>
    /// returns view for users to sign up
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> RegisterView()
    {
        var dto = new NewUserRequest();
        return View(dto);
    }
}

