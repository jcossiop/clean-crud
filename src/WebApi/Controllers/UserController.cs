using Application.Features.Representatives.Abstractions;
using Application.Features.Representatives.Services;
using Application.Features.Users.Abstractions;
using Application.Features.Users.DTOs;
using Domain.Representatives;
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
        return await _userService.Add(userDto);
    }
}
