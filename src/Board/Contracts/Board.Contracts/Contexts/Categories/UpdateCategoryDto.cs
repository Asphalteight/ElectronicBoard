namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Модель изменения категории.
/// </summary>
public class UpdateCategoryDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;
}