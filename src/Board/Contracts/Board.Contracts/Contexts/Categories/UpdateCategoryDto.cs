namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Модель изменения категории.
/// </summary>
public class UpdateCategoryDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
}