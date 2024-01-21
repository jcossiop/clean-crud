using System.ComponentModel.DataAnnotations;

namespace Domain.Users;

public class User
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

    /// <summary>
    /// Created Date.
    /// </summary>
    public int Created { get; set; }

}
