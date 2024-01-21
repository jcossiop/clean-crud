using Application.Features.Users.DTOs;

namespace Application.Features.Users.Abstractions;

/// <summary>
/// Use DTOs for contracts. Use case is similar to the repository (in this case).
/// A service that defines application logic related to this feature
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Add a User.
    /// </summary>
    /// <param name="user">User entity.</param>
    /// <returns>The persisted user.</returns>
    Task<UserDto> Add(UserDto user);
}
