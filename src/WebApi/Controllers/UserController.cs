using Application.Features.Users.Abstractions;
using Application.Features.Users.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
    public async Task<ActionResult<UserDto>> Register(UserDto userDto)
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
            var response = await _userService.Login(userDto);
            // Add token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("144bc73a-1c0d-41b3-8104-e1fc43db45c9");
            TimeSpan tokenLifeSpan = TimeSpan.FromHours(8);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userDto.UserName),
                new(JwtRegisteredClaimNames.Email, userDto.UserName),
                new("userid", userDto.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            { 
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(tokenLifeSpan),
                Issuer = "https://id.sammple.com",
                Audience = "https://reps.sammple.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            response.Token = jwt;

            return response;
        }
        catch (Exception ex)
        {
            return Problem("Internal server error.");
        }
    }
}
