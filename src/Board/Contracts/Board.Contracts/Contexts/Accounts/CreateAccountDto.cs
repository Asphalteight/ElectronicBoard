namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель создания аккаунта.
/// </summary>
public class CreateAccountDto
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string? Phone { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
}