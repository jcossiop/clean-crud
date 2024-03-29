﻿using CleanCrud.Application.Features.Representatives.Abstractions;
using CleanCrud.Application.Features.Representatives.DTOs;
using CleanCrud.Application.Features.Representatives.Mappings;

namespace CleanCrud.Application.Features.Representatives.Services;

/// <summary>
/// Implementation of the application logic for this feature. As defined in the abstractions folder
/// </summary>
public class RepresentativeService : IRepresentativeService
{
    private readonly IRepresentativeRepository _repository;

    /// <summary>
    /// Constructor using dependency injection to get a repository.
    /// </summary>
    /// <param name="repository">Injected repository.</param>
    public RepresentativeService(IRepresentativeRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get all the Representativers.
    /// </summary>
    /// <returns>List of Representatives.</returns>
    public async Task<List<RepresentativeDto>> GetAll()
    {
        var output = await _repository.GetAll();
        // Convert to DTOs List (to remove some domain fields)
        return output.Select(x => x.ToRepresentativeDto()).ToList();
    }

    /// <summary>
    /// Add a Representative.
    /// </summary>
    /// <param name="representativeDto">Entity to persist.</param>
    /// <returns>Persited entity.</returns>
    public async Task<RepresentativeDto> Add(RepresentativeDto representativeDto)
    {
        var output = await _repository.Add(representativeDto.ToRepresentative());
        return output.ToRepresentativeDto();
    }

    /// <summary>
    /// Remove a representative.
    /// </summary>
    /// <param name="representativeId">Id of the Representative.</param>
    /// <returns>Task</returns>
    public async Task Delete(int representativeId)
    {
        await _repository.Delete(representativeId);
    }

    /// <summary>
    /// Update a Representative.
    /// </summary>
    /// <param name="representativeDto">Entity to Update.</param>
    /// <returns>Updated entity.</returns>
    public async Task<RepresentativeDto> Update(RepresentativeDto representativeDto)
    {
        var output = await _repository.Update(representativeDto.ToRepresentative());
        return output.ToRepresentativeDto();
    }
}
