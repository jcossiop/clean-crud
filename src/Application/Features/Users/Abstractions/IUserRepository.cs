using Domain.Users;

namespace Application.Features.Users.Abstractions;

/// <summary>
/// User repository interface.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Persist a User.
    /// </summary>
    /// <param name="user">User entity.</param>
    /// <returns>The persisted user.</returns>
    Task<User> Add(User user);

    /// <summary>
    /// Login a User.
    /// </summary>
    /// <param name="user">User entity.</param>
    /// <returns>Login State.</returns>
    Task<LoginResult> Login(User user);

}
