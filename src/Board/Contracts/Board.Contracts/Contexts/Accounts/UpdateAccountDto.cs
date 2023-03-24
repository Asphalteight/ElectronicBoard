namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель изменения аккаунта.
/// </summary>
public class UpdateAccountDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }
    
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