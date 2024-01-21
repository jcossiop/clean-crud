using Application.Features.Representatives.Abstractions;
using Application.Features.Representatives.DTOs;
using Application.Features.Representatives.Mappings;

namespace Application.Features.Representatives.Services;

public class RepresentativeService : IRepresentativeService
{
    private IRepresentativeRepository _repository;

    /// <summary>
    /// Constructor using dependency injection to get a repository.
    /// </summary>
    /// <param name="repository">Injected repository.</param>
    public RepresentativeService(IRepresentativeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RepresentativeDto>> GetAll()
    {
        var output = await _repository.GetAll();
        // Convert to DTOs List (to remove some domain fields)
        return output.Select(x => x.ToRepresentativeDto()).ToList();
    }

    public async Task<RepresentativeDto> Add(RepresentativeDto representative)
    {
        var output = await _repository.Add(representative.ToRepresentative());
        return output.ToRepresentativeDto();
    }

    public async Task Delete(int representativeId)
    {
        await _repository.Delete(representativeId);
    }

    public async Task<RepresentativeDto> Update(RepresentativeDto representative)
    {
        var output = await _repository.Update(representative.ToRepresentative());
        return output.ToRepresentativeDto();
    }
}
