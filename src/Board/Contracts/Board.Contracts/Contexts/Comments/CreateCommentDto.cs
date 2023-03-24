namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель создания комментария.
/// </summary>
public class CreateCommentDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Дата и время создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvertisementId { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int AccountId { get; set; }
}