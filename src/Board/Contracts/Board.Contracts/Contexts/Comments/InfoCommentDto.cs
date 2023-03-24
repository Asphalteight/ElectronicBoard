namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Информация о комментарии.
/// </summary>
public class InfoCommentDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

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