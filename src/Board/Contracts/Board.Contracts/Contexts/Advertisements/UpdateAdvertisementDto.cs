namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Модель изменения объявления.
/// </summary>
public class UpdateAdvertisementDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }
    
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
    /// Активно ли.
    /// </summary>
    public bool IsActive { get; set; } = true;
}