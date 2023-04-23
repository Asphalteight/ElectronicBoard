namespace Board.Contracts.Contexts.Subcategories;

/// <summary>
/// Модель создания подкатегории.
/// </summary>
public class CreateSubcategoryDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }

}