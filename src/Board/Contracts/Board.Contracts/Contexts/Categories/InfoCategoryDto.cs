namespace Board.Contracts.Contexts.Categories;

/// <summary>
/// Информация о категории.
/// </summary>
public class InfoCategoryDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
}