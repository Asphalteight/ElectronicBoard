namespace Board.Domain.Category;

/// <summary>
/// Категории.
/// </summary>
public class Categories
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
    /// Список подкатегорий.
    /// </summary>
    public virtual List<Subcategories> SubcategoriesList { get; set; }
}