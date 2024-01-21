using Application.Features.Users.Abstractions;
using Application.Features.Users.DTOs;
using Application.Features.Users.Mappings;

namespace Application.Features.Users.Services;

/// <summary>
/// Implementation of the application logic for this feature. As defined in the abstractions folder
/// </summary>
public class UserService: IUserService
{
    private IUserRepository _repository;

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
    /// <param name="user">Entity to persist.</param>
    /// <returns>Persited entity.</returns>
    public async Task<UserDto> Add(UserDto user)
    {
        var output = await _repository.Add(user.ToUser());
        return output.ToUserDto();
    }
}
