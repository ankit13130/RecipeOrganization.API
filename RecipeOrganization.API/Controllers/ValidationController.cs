using Microsoft.AspNetCore.Mvc;
using RecipeOrganization.Core.Contract;
using RecipeOrganization.Core.Domain.RequestModels;

namespace RecipeOrganization.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValidationController : ControllerBase
{
    private readonly IValidationServices _validationServices;
    public ValidationController(IValidationServices validationServices)
    {
        _validationServices = validationServices;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
    {
        var response = await _validationServices.ValidateLoginAsync(loginRequestModel);
        //int sid;
        //if(Int32.TryParse(User.FindFirstValue(ClaimTypes.Sid), out sid))
        //{
        //    HttpContext.Session.SetInt32("Sid",sid);
        //}
        return Ok(response == null ? Unauthorized() : response);
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromForm] UserRequestModel userRequestModel)
    {
        await _validationServices.ValidateSignupAsync(userRequestModel);
        return Ok("Success");
    }
}
