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
    public string Title { get; set; }
    
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
    public string Address { get; set; }
    
    /// <summary>
    /// Дата и время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Активно ли объявление.
    /// </summary>
    public bool IsActive { get; set; }
    
    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Категория.
    /// </summary>
    public virtual Categories Category { get; set; }
    
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
    public virtual Accounts Account { get; set; }
    
    /// <summary>
    /// Список комментариев.
    /// </summary>
    public virtual List<Comments>? CommentsList { get; set; } 
}