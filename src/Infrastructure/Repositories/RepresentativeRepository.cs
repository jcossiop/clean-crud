using Application.Features.Representatives.Abstractions;
using Domain.Representatives;

namespace Infrastructure.Repositories;

public class RepresentativeRepository : IRepresentativeRepository
{
    public Task<List<Representative>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Representative> Add(Representative representative)
    {
        throw new NotImplementedException();
    }

    public Task<Representative> Update(Representative representative)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int representativeId)
    {
        throw new NotImplementedException();
    }
}
