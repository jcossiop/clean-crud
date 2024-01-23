using CleanCrud.Application.Common.Interfaces;
using CleanCrud.Application.Features.Representatives.Abstractions;
using CleanCrud.Domain.Representatives;

namespace CleanCrud.Infrastructure.Repositories;

/// <summary>
/// Representative Repository Interface.
/// </summary>
public class RepresentativeRepository : IRepresentativeRepository
{
    private readonly IAppDbContext _appDbContext;

    /// <summary>
    /// Contructor for injecting the db context
    /// </summary>
    /// <param name="appDbContext">Injected context</param>
    public RepresentativeRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <summary>
    /// Get all representatives.
    /// </summary>
    /// <returns>List of Representatives.</returns>
    public async Task<List<Representative>> GetAll()
    {
        return await _appDbContext.GetRepresentatives();
    }

    /// <summary>
    /// Add a Representative.
    /// </summary>
    /// <param name="representative">Representative entity.</param>
    /// <returns>The persisted representative.</returns>
    public async Task<Representative> Add(Representative representative)
    {
        // Gather missing information (Whom)
        representative.CreatedBy = representative.User;
        return await _appDbContext.AddRepresentative(representative);
    }

    /// <summary>
    /// Update a representative.
    /// </summary>
    /// <param name="representative">Representative to update.</param>
    /// <returns>Updated representative.</returns>
    public async Task<Representative> Update(Representative representative)
    {
        // Gather missing information (Whom)
        representative.ModifiedBy = representative.User;
        return await _appDbContext.UpdateRepresentative(representative);
    }

    /// <summary>
    /// Remove a representative from storage.
    /// </summary>
    /// <param name="representativeId">Representative Id.</param>
    /// <returns>Task.</returns>
    public async Task Delete(int representativeId)
    {
        await _appDbContext.DeleteRepresentative(representativeId);
    }
}
