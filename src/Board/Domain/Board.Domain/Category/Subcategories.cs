using Board.Domain.Advertisement;

namespace Board.Domain.Category;

/// <summary>
/// Подкатегория.
/// </summary>
public class Subcategories
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Категория.
    /// </summary>
    public virtual Categories Category { get; set; }
    
    /// <summary>
    /// Список объявлений.
    /// </summary>
    public virtual List<Advertisements> AdvertisementsList { get; }
}