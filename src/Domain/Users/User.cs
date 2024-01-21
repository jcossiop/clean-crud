using System.ComponentModel.DataAnnotations;

namespace Domain.Users;

internal class User
{
    /// <summary>
    /// User name.
    /// </summary>
    [Key]
    public string UserName { get; set; }

    /// <summary>
    /// Password hash.
    /// </summary>
    [Required]
    public string PasswordHash { get; set; }
}
