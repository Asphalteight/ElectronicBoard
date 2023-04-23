namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель для входа в аккаунт.
/// </summary>
public class LoginAccountDto
{
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
}