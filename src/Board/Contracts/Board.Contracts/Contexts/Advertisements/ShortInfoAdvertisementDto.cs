namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Краткая информация об объявлении.
/// </summary>
public class ShortInfoAdvertisementDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; }
}