namespace Board.Contracts.Contexts.Subcategories;

/// <summary>
/// Информация о подкатегории.
/// </summary>
public class InfoSubcategoryDto
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
}