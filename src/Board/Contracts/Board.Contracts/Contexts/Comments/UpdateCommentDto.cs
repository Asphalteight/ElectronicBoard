namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель изменения комментария.
/// </summary>
public class UpdateCommentDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    public string? Text { get; set; }
}