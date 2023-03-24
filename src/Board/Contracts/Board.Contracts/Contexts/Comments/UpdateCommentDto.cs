namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель изменения комментария.
/// </summary>
public class UpdateCommentDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; }
}