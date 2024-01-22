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
    public async Task<User> Add(User user)
    {
        return await _appDbContext.AddUser(user);
    }

    /// <summary>
    /// Login a User.
    /// </summary>
    /// <param name="user">User entity.</param>
    /// <returns>Login State.</returns>
    public async Task<LoginResult> Login(User user)
    {
        return await _appDbContext.LoginUser(user);
    }
}
