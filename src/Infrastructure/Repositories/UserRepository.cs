using Application.Features.Users.Abstractions;
using Domain.Users;

namespace Infrastructure.Repositories;

/// <summary>
/// User repository interface.
/// </summary>
public class UserRepository : IUserRepository
{
    /// <summary>
    /// Persist a user.
    /// </summary>
    /// <param name="user">User to persist.</param>
    /// <returns>Persited user.</returns>
    public Task<User> Add(User user)
    {
        // Connect to the repository

        // Gather missing information (Stored Date)

        // Store the entity

        // Return the stored entity
        return Task.FromResult<User>(user);
    }
}
