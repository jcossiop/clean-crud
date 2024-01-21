namespace Application.Features.Users.DTOs;

public class UserDto
{
    /// <summary>
    /// User name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Password hash.
    /// </summary>
    public string PasswordHash { get; set; }
}
