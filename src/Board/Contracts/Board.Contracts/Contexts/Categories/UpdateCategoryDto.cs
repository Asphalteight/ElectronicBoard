namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Модель изменения категории.
/// </summary>
public class UpdateCategoryDto
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