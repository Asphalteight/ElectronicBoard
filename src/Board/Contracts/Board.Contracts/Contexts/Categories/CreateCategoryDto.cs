using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "Не указано наименование")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Наименование имеет недопустимую длину")]
    public string Name { get; set; } = null!;
}