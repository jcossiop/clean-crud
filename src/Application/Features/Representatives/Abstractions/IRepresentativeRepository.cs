using Domain.Representatives;

namespace Application.Features.Representatives.Abstractions;

/// <summary>
/// Representative repository interface.
/// A repository that defines logic for how this feature needs to interact with the persistence engine.
/// </summary>
public interface IRepresentativeRepository
{
    /// <summary>
    /// Get all the persisted Representatives.
    /// </summary>
    /// <returns>List of Representatives</returns>
    Task<List<Representative>> GetAll();

    /// <summary>
    /// Add a Representative.
    /// </summary>
    /// <param name="representative">Representative entity.</param>
    /// <returns>The persisted representative.</returns>
    Task<Representative> Add(Representative representative);

    /// <summary>
    /// Update (patch) a representative.
    /// </summary>
    /// <param name="representative">Representative to update.</param>
    /// <returns>Updated representative.</returns>
    Task<Representative> Update(Representative representative);

    /// <summary>
    /// Remove a representative from storage.
    /// </summary>
    /// <param name="representativeId">Representative Id.</param>
    /// <returns>Task.</returns>
    Task Delete(int representativeId);
}
