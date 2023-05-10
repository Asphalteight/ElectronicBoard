using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Advertisements;

/// <summary>
/// Модель изменения объявления.
/// </summary>
public class UpdateAdvertisementDto
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    [Required(ErrorMessage = "Не указан заголовок объявления")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Заголовок имеет недопустимую длину")]
    public string Title { get; set; } = null!;

    /// <summary>
    /// Описание.
    /// </summary>
    [StringLength(500, ErrorMessage = "Описание превышает допустимую длину")]
    public string? Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    [Required(ErrorMessage = "Адрес не указан")]
    [StringLength(250, ErrorMessage = "Адрес превышает допустимую длину")]
    public string Address { get; set; } = null!;
    
    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; } = true;
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    [Required(ErrorMessage = "Не указан идентификатор категории")]
    public int CategoryId { get; set; }
}