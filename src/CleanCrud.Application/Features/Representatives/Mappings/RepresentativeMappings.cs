using CleanCrud.Application.Features.Representatives.DTOs;
using CleanCrud.Domain.Representatives;

namespace CleanCrud.Application.Features.Representatives.Mappings;

/// <summary>
/// Allow mapping for domain entities to DTOs and vice versa.
/// Can be done with automapper as well.
/// </summary>
public static class RepresentativeMappings
{
    /// <summary>
    /// Convert from domain entity to DTO.
    /// </summary>
    /// <param name="representative">Representative entity.</param>
    /// <returns>Representative DTO.</returns>
    public static RepresentativeDto ToRepresentativeDto(this Representative representative)
    {
        return new RepresentativeDto
        {
            Id = representative.Id,
            Name = representative.Name,
            CellPhone = representative.CellPhone,
            Email = representative.Email,
            Role = representative.Role,
            Company = representative.Company,
            Brands = representative.Brands
        };
    }

    /// <summary>
    /// Convert from DTO to domain.
    /// </summary>
    /// <param name="representativeDto">Representative DTO entity.</param>
    /// <returns>Representative.</returns>
    public static Representative ToRepresentative(this RepresentativeDto representativeDto)
    {
        return new Representative
        {
            Id = representativeDto.Id,
            Name = representativeDto.Name,
            CellPhone = representativeDto.CellPhone,
            Email = representativeDto.Email,
            Role = representativeDto.Role,
            Company = representativeDto.Company,
            Brands = representativeDto.Brands,
            User = representativeDto.User
        };
    }
}
