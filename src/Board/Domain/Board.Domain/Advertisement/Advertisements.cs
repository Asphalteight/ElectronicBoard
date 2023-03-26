using Board.Domain.Account;
using Board.Domain.Category;
using Board.Domain.Comment;

namespace Board.Domain.Advertisement;

/// <summary>
/// Объявления.
/// </summary>
public class Advertisements
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; } = null!;
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Дата и время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Активно ли.
    /// </summary>
    public bool IsActive { get; set; } = true;
    
    /// <summary>
    /// Идентификатор подкатегории.
    /// </summary>
    public int SubcategoryId { get; set; }
    
    /// <summary>
    /// Подкатегория.
    /// </summary>
    public virtual Subcategories Subcategory { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Пользователь.
    /// </summary>
    public virtual Accounts Account { get; set; } = null!;
    
    /// <summary>
    /// Список комментариев.
    /// </summary>
    public virtual List<Comments>? CommentsList { get; set; } 
}