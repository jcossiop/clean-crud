using CleanCrud.App.Services;

namespace CleanCrud.App.Contracts;

public interface IRepresentativeDataService
{
    public Task<List<RepresentativeDto>> GetAllRepresentatives();
    public Task DeleteRepresentative(long id);
}
