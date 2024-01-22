namespace Domain.Users;

public class User
{
    /// <summary>
    /// User name.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// Password hash.
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// Created Date.
    /// </summary>
    public long? Created { get; set; }

}
