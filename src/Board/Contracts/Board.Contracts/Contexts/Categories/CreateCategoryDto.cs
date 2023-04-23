namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Модель создания категории.
/// </summary>
public class CreateCategoryDto
{
    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public int ParentCategoryId { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;
}