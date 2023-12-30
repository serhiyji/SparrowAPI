using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparrowAPI.Core.DTOs.User;
using SparrowAPI.Core.Services;
using SparrowAPI.Core.Validation.User;

namespace SparrowAPI.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            this._userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this._userService.GetAllAsync());
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var validationResult = await new LoginUserValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _userService.LoginUserAsync(model);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response.Errors.FirstOrDefault());
            }
            return BadRequest(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] CreateUserDto model)
        {
            var validationResult = await new CreateUserValidation().ValidateAsync(model);
            if (validationResult.IsValid)
            {
                ServiceResponse response = await _userService.CreateUserAsync(model);
                if (response.Success)
                {
                    return Ok(response.Message);
                }
                return Ok(response.Errors.FirstOrDefault());
            }
            return Ok(validationResult.Errors.FirstOrDefault());
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserDto model)
        {
            ServiceResponse result = await _userService.DeleteUserAsync(model.Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors.FirstOrDefault());
        }
    }
}
