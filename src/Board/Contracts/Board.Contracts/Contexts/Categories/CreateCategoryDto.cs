namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Модель создания категории.
/// </summary>
public class CreateCategoryDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;
}