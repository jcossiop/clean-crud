using Application.Features.Representatives.Abstractions;
using Domain.Representatives;

namespace Infrastructure.Repositories;

/// <summary>
/// Representative Repository Interface.
/// </summary>
public class RepresentativeRepository : IRepresentativeRepository
{
    public Task<List<Representative>> GetAll()
    {
        var dummyList = new List<Representative>();
        dummyList.Add(new Representative { 
            Name = "Shelly Smith",
            CellPhone = "(217) 436-2287",
            Email = "SSmith@lilly.com",
            Role = "Sales Representative",
            Company = "Eli Lilly",
            Brands = "Trulicity, Verzenio, Emgality"
        });
        dummyList.Add(new Representative
        {
            Name = "Terry Lawson",
            CellPhone = "(917) 446-0087",
            Email = "Terry@Bayer.com",
            Role = "Sales Representative",
            Company = "Bayer",
            Brands = "Glucobay, Adalat, Adempas"
        });
        dummyList.Add(new Representative
        {
            Name = "Emily Dickinson",
            CellPhone = "(314) 501-3342",
            Email = "Emily@Roche.com",
            Role = "Sales Representative",
            Company = "Roche",
            Brands = "Hemlibre, Cellcept"
        });
        return Task.FromResult<List<Representative>>(dummyList);
    }

    public Task<Representative> Add(Representative representative)
    {
        // Connect to the repository

        // Gather missing information (Stored Date)

        // Store the entity

        // Return the stored entity
        return Task.FromResult<Representative>(representative);
    }

    public Task<Representative> Update(Representative representative)
    {
        // Connect to the repository

        // Gather missing information (Stored Date)

        // Store the entity

        // Return the stored entity
        return Task.FromResult<Representative>(representative);
    }

    public Task Delete(int representativeId)
    {
        return Task.CompletedTask;
    }
}
