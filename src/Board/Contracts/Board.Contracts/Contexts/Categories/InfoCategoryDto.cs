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
    /// Идентификатор родительской категории.
    /// </summary>
    public int ParentCategoryId { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }
}