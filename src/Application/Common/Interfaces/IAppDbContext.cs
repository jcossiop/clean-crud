using Application.Features.Users.Abstractions;
using Domain.Representatives;
using Domain.Users;

namespace Application.Common.Interfaces;

/// <summary>
/// Application Context interface definition.
/// </summary>
public interface IAppDbContext
{
    /// <summary>
    /// Get all representatives.
    /// </summary>
    /// <returns>List of representatives.</returns>
    public Task<List<Representative>> GetRepresentatives();

    /// <summary>
    /// Add representative.
    /// </summary>
    /// <param name="representative">The element to add.</param>
    /// <returns>The added element.</returns>
    public Task<Representative> AddRepresentative(Representative representative);

    /// <summary>
    /// Update representative.
    /// </summary>
    /// <param name="representative">The element to modify.</param>
    /// <returns>The modified element.</returns>
    public Task<Representative> UpdateRepresentative(Representative representative);

    /// <summary>
    /// Remove a representative.
    /// </summary>
    /// <param name="id">The representative id to removde</param>
    /// <returns>Task</returns>
    public Task DeleteRepresentative(long id);

    /// <summary>
    /// Add user.
    /// </summary>
    /// <param name="user">The element to add.</param>
    /// <returns>The added element.</returns>
    public Task<User?> AddUser(User user);

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="user">User details.</param>
    /// <returns>Login Status.</returns>
    public Task<LoginResult> LoginUser(User user);

}
