using Application.Features.Users.Abstractions;
using Application.Features.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/// <summary>
/// Controller for all user methods
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <summary>
    /// Constructor injecting the service
    /// </summary>
    /// <param name="userService">Injected Service.</param>
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Add a User.
    /// </summary>
    /// <param name="userDto">User to persist.</param>
    /// <returns>Stored Representative.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserDto>> Add(UserDto userDto)
    {
        try
        {
            var response = await _userService.Add(userDto);
            if (response == null)
            {
                return Problem("Unable to add a user at this moment.");
            }
            return Ok(response);
        }
        catch
        {
            return Problem("Unable to add a user at this moment.");
        }
    }

    /// <summary>
    /// Login a User.
    /// </summary>
    /// <param name="userDto">User info.</param>
    /// <returns>Login Status.</returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LoginResult>> Login(UserDto userDto)
    {
        if (userDto == null || string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.PasswordHash))
            return BadRequest("Invalid parameters.");

        try
        {
            return await _userService.Login(userDto);
        }
        catch
        {
            return Problem("Internal server error.");
        }
    }
}
