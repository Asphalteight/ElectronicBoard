namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Модель поиска объявления.
/// </summary>
public class SearchAdvertisementDto
{
    /// <summary>
    /// Текст поиска.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; } = true;
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }
    
    public int Take { get; set; }
    public int Skip { get; set; }
}