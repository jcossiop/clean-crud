using System.ComponentModel.DataAnnotations;

namespace Application.Features.Representatives.DTOs;

/// <summary>
/// DTO used for interacting with the outer layer.
/// </summary>
public class RepresentativeDto
{
    /// <summary>
    /// Rep Id (internal).
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Rep Name.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; set; }

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

}
