using System.Text.RegularExpressions;

namespace Domain.Representatives;

public class Representative
{
    /// <summary>
    /// Rep Id (internal).
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Rep Name.
    /// </summary>
    public required string Name { get; set; }

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
    /// User who created this record.
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Date record created.
    /// </summary>
    public long? Created { get; set; }

    /// <summary>
    /// User who modified this record.
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// Modified date.
    /// </summary>
    public long? Modified { get; set; }

    /// <summary>
    /// Temp field
    /// </summary>
    public string? User { get; set; }

    /// <summary>
    /// Check email format.
    /// </summary>
    /// <returns>True if valid.</returns>
    public bool IsEmailValid()
    {
        if (Email != null)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(Email, regex, RegexOptions.IgnoreCase);
        }
        else
            return false;
    }
}
