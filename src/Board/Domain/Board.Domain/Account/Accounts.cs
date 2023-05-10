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
    
    /// <summary>
    /// Дата/время регистрации.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Идентификатор картинки для аватара.
    /// </summary>
    public Guid? PictureId { get; set; }
    
    /// <summary>
    /// Список объявлений.
    /// </summary>
    public virtual List<Advertisements>? AdvertisementsList { get; set; }
}