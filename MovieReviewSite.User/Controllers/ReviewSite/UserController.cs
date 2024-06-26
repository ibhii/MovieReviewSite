﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<List<BaseUserModel>> GetAllUsers(AllUsersListRequest dto)
    {
        return await _userRepository.GetAllUsers(dto);
    }

    [HttpGet("[action]")]
    public async Task<BaseUserModel?> GetUserById([FromQuery] int id)
    {
        return await _userRepository.GetUserById(id);
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> AddUser([FromBody] NewUserRequest dto)
    {
        await _userRepository.AddUser(dto);
        return RedirectToAction("LoginView","User");

    }

    [Authorize]
    [HttpPost("[action]/{id}")]
    public async Task UpdateUser(int id, [FromBody] UpdateUserRequest dto)
    {
        await _userRepository.UpdateUser(id, dto);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost("[action]/{id}")]
    public async Task DeactivateUser(int id)
    {
        await _userRepository.DeactivateUser(id);
    }

    /// <summary>
    /// changes a users role
    /// </summary>
    /// <param name="dto"></param>
    [Authorize(Policy = "AdminOnly")]
    [HttpPost("[action]")]
    public async Task ChangeUserRole([FromBody] UserRole dto)
    {
        await _userRepository.ChangeUserRole(dto);
    }

    /// <summary>
    /// checks if entered information is correct then logs user in
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest dto)
    {
        await _userRepository.LoginUser(dto);
        return RedirectToAction("GetAllMoviesList","Home");
    }

    [Authorize]
    [HttpPost("[action]")]
    public async Task<IActionResult> LogoutUser()
    {
        await _userRepository.LogoutUser();
        return RedirectToAction("GetAllMoviesList","Home");
    }


    /// <summary>
    /// returns a view with the list of all users 
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> GetAllUsersView(string? searchString)
    {
        var result = new AllUsersViewModel();
        @ViewData["CurrentFilter"] = searchString;
        var dto = new AllUsersListRequest
        {
            Search = searchString
        };
        result.User = await _userRepository.GetAllUsers(dto);
        return View(result);
    }

    /// <summary>
    /// returns view with users details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> UserDetailView(int id)
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
    public async Task<ActionResult> UserUpdateView(int id)
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

    /// <summary>
    /// returns a view that admin can change user roles in it
    /// </summary>
    /// <returns></returns>
    [Route("[action]")]
    public async Task<ActionResult> ChangeUserRoleView()
    {
        var dto = new AllUsersListRequest();
        var request = new UserRole();
        var users = await _userRepository.GetAllUsers(dto);
        var roles = await _userRepository.GetAllRoles();
        var result = new ChangeUserRoleViewModel()
        {
            Users = users,
            Roles = roles
        };
        return View(result);
    }


    /// <summary>
    /// this is for users whom where created before hashing the password so that i can later add the hashed passwords
    /// </summary>
    /// <returns></returns>
    [HttpPost("[action]/{id}")]
    public async Task SaveUserHashedPassword(int id)
    {
        await _userRepository.GetUserAuthInfo(id);
    }
    

    [Route("[action]")]
    public async Task<ActionResult> UserLogoutView()
    {
        return View();
    }

}
