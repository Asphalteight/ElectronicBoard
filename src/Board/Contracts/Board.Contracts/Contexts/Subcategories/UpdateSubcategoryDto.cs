namespace Board.Contracts.Contexts.Subcategories;

/// <summary>
/// Модель изменения подкатегории.
/// </summary>
public class UpdateSubcategoryDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }
}