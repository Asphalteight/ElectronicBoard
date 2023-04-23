namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Информация об объявлении.
/// </summary>
public class InfoAdvertisementDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Дата и время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; } = true;
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int AccountId { get; set; }
}