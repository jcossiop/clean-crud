using System.ComponentModel.DataAnnotations;

namespace Domain.Representatives;

public class Representative
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

    /// <summary>
    /// User who created this record.
    /// </summary>
    public string CreatedBy { get; set; }

    /// <summary>
    /// Date record created.
    /// </summary>
    public int Created { get; set; }

    /// <summary>
    /// User who modified this record.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified date.
    /// </summary>
    public int? Modified { get; set; }
}
