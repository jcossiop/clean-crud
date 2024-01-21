using Application.Features.Users.DTOs;
using Domain.Users;

namespace Application.Features.Users.Mappings;

/// <summary>
/// Allow mapping for domain entities to DTOs and vice versa.
/// Can be done with automapper as well.
/// </summary>
public static class UserMappings
{
    /// <summary>
    /// Convert from domain entity to DTO.
    /// </summary>
    /// <param name="user">User entity.</param>
    /// <returns>User DTO.</returns>
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            UserName = user.UserName,
            PasswordHash = user.PasswordHash
        };
    }

    /// <summary>
    /// Convert from DTO to domain.
    /// </summary>
    /// <param name="userDto">Representative DTO entity.</param>
    /// <returns>Representative.</returns>
    public static User ToUser(this UserDto userDto)
    {
        return new User
        {
            UserName = userDto.UserName,
            PasswordHash = userDto.PasswordHash
        };
    }
}
