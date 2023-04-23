namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель результата входа в аккаунт.
/// </summary>
public class LoginResultDto
{
    /// <summary>
    /// Токен авторизации.
    /// </summary>
    public string Token { get; set; }
}