using Board.Domain.Advertisement;

namespace Board.Domain.Account;

/// <summary>
/// Аккаунты.
/// </summary>
public class Accounts
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string? Phone { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// Список объявлений.
    /// </summary>
    public virtual List<Advertisements>? AdvertisementsList { get; set; }
}