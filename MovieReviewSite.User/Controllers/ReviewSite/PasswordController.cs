using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReviewSite.Core.Interfaces.ReviewSite;
using MovieReviewSite.Core.Models.Password;
using MovieReviewSite.Core.Models.Password.Requests;
using MovieReviewSite.Core.Models.Password.ViewModels;

namespace MovieReviewSite.Controllers.ReviewSite;

[Route("[controller]")]
public class PasswordController : Controller
{
    private readonly IPasswordRepository _repository;

    public PasswordController(IPasswordRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// returns password by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<string?> GetById(int id)
    {
        return await _repository.GetById(id);
    }

    /// <summary>
    /// returns password for a user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<List<BasePassword>> GetPasswordsByUserId(int id)
    {
        return await _repository.GetPasswordsByUserId(id);
    }

    /// <summary>
    /// returns users most recent password
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<BasePassword?> GetUsersCurrentPassword(int id)
    {
        return await _repository.GetUsersCurrentPassword(id);
    }

    /// <summary>
    /// gets users last used password
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public async Task<BasePassword?> GetUsersLastPassword(int id)
    {
        return await _repository.GetUsersLastPassword(id);
    }

    /// <summary>
    /// updates users password
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    [Authorize]
    [HttpPost("[action]/{id}")]
    public async Task ChangePasswordByUserId(int id,[FromBody] UpdatePasswordRequest dto)
    {
        await _repository.ChangePasswordByUserId(id,dto);
    }
    
    /// <summary>
    /// returns a view that changes user password
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Route("[action]/{id}")]
    public async Task<ActionResult> ChangeUserPasswordView(int id)
    {
        var password = await _repository.GetPasswordForUserDetailsByUserId(id);
        var result = new ChangeUserPasswordViewModel()
        {
            Password = password
        };
        return View(result);
    }
}
