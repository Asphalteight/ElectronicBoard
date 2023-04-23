using Board.Domain.Account;
using Board.Domain.Category;
using Board.Domain.Comment;
using Board.Domain.ImageKit;

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
    /// Адрес.
    /// </summary>
    public string Address { get; set; } = null!;
    
    /// <summary>
    /// Дата и время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; } = true;
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public virtual Categories Category { get; set; } = null!;
    
    /// <summary>
    /// Набор изображений.
    /// </summary>
    public ImageKits ImageKit { get; set; }
    
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