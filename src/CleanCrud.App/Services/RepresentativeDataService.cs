using CleanCrud.App.Contracts;

namespace CleanCrud.App.Services;

public class RepresentativeDataService: IRepresentativeDataService
{
    private readonly IClient _client;

    public RepresentativeDataService(IClient client)
    {
        _client = client;
    }

    public async Task<List<RepresentativeDto>> GetAllRepresentatives()
    {
        var allRepresentatives = await _client.GetAllAsync();
        return allRepresentatives.ToList();
    }

    public async Task DeleteRepresentative(long id)
    {
        await _client.RepresentativeDELETEAsync(Convert.ToInt32(id));
    }
}
