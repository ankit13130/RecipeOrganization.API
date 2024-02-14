using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeOrganization.Core.Contract;
using RecipeOrganization.Core.Domain.RequestModels;
using System.Security.Claims;

namespace RecipeOrganization.API.Controllers;

[Authorize(Roles = "user,admin")]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    public UserController(IUserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetUser(long userId)
    {
        return Ok(await _userServices.GetUser(userId));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserRequestModel userRequestModel)
    {
        await _userServices.UpdateUser(userRequestModel,Convert.ToInt64(User.FindFirstValue(ClaimTypes.Sid)));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(long userId)
    {
        await _userServices.DeleteUser(userId,Convert.ToInt64(User.FindFirstValue(ClaimTypes.Sid)));
        return Ok();
    }
}
