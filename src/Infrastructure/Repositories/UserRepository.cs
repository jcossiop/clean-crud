using Application.Common.Interfaces;
using Application.Features.Users.Abstractions;
using Domain.Users;

namespace Infrastructure.Repositories;

/// <summary>
/// User repository interface.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly IAppDbContext _appDbContext;

    /// <summary>
    /// Contructor for injecting the db context
    /// </summary>
    /// <param name="appDbContext">Injected context</param>
    public UserRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    /// <summary>
    /// Persist a user.
    /// </summary>
    /// <param name="user">User to persist.</param>
    /// <returns>Persited user.</returns>
    public Task<User> Add(User user)
    {
        // Connect to the repository

        // Gather missing information (Created Date)
        user.Created = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

        // Store the entity

        // Return the stored entity
        return Task.FromResult<User>(user);
    }
}
