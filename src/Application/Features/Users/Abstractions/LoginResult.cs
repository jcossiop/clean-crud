namespace Application.Features.Users.Abstractions;

/// <summary>
/// Login Result.
/// </summary>
public class LoginResult
{
    /// <summary>
    /// Success Status.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Any relevant message.
    /// </summary>
    public string? Message { get; set; }
}
