namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Модель частичного изменения объявления.
/// </summary>
public class UpdateAdvertisementDto
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public string Address { get; set; } = null!;
    
    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; } = true;
}