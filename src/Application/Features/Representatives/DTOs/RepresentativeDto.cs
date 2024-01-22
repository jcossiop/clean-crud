using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Features.Representatives.DTOs;

/// <summary>
/// DTO used for interacting with the outer layer.
/// This is what can be exposed externally, containing precisely the properties needed by external consumers of the API.
/// </summary>
public class RepresentativeDto
{
    /// <summary>
    /// Rep Id (internal).
    /// </summary>
    [Key]
    public long Id { get; set; }

    /// <summary>
    /// Rep Name.
    /// </summary>
    public required string? Name { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Cell Phone.
    /// </summary>
    public string? CellPhone { get; set; }

    /// <summary>
    /// Role.
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// Company the Rep works for.
    /// </summary>
    public string? Company { get; set; }

    /// <summary>
    /// Brands this Rep is in charge for.
    /// </summary>
    public string? Brands { get; set; }

    /// <summary>
    /// Temp field
    /// </summary>
    [JsonIgnore]
    public string? User { get; set; }

}
