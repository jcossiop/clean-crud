using Application.Features.Users.Abstractions;
using Application.Features.Users.DTOs;
using Application.Features.Users.Mappings;

namespace Application.Features.Users.Services;

/// <summary>
/// Implementation of the application logic for this feature. As defined in the abstractions folder
/// </summary>
public class UserService: IUserService
{
    private readonly IUserRepository _repository;

    /// <summary>
    /// Constructor using dependency injection to get a repository.
    /// </summary>
    /// <param name="repository">Injected repository.</param>
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Add a user.
    /// </summary>
    /// <param name="userDto">Entity to persist.</param>
    /// <returns>Persited entity.</returns>
    public async Task<UserDto?> Add(UserDto userDto)
    {
        var output = await _repository.Add(userDto.ToUser());
        if (output != null)
            return output.ToUserDto();
        else
            return null;
    }

    /// <summary>
    /// Login a User.
    /// </summary>
    /// <param name="userDto">User entity.</param>
    /// <returns>Login State.</returns>
    public async Task<LoginResult> Login(UserDto userDto)
    {
        return await _repository.Login(userDto.ToUser());
    }
}
