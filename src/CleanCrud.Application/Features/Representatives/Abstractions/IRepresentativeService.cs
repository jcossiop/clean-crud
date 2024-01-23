using CleanCrud.Application.Features.Representatives.DTOs;

namespace CleanCrud.Application.Features.Representatives.Abstractions;

/// <summary>
/// Use DTOs for contracts. Use case is similar to the repository (in this case).
/// A service that defines application logic related to this feature
/// </summary>
public interface IRepresentativeService
{
    /// <summary>
    /// Get all the persisted Representatives.
    /// </summary>
    /// <returns>List of Representatives</returns>
    Task<List<RepresentativeDto>> GetAll();

    /// <summary>
    /// Add a Representative.
    /// </summary>
    /// <param name="representativeDto">Representative entity.</param>
    /// <returns>The persisted representative.</returns>
    Task<RepresentativeDto> Add(RepresentativeDto representativeDto);

    /// <summary>
    /// Update (patch) a representative.
    /// </summary>
    /// <param name="representativeDto">Representative to update.</param>
    /// <returns>Updated representative.</returns>
    Task<RepresentativeDto> Update(RepresentativeDto representativeDto);

    /// <summary>
    /// Remove a representative from storage.
    /// </summary>
    /// <param name="representativeId">Representative Id.</param>
    /// <returns>Task.</returns>
    Task Delete(int representativeId);
}
