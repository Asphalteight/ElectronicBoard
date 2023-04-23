namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Модель создания объявления.
/// </summary>
public class CreateAdvertisementDto
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
    /// Идентификатор подкатегории.
    /// </summary>
    public int SubcategoryId { get; set; }
}