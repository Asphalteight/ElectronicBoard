namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель создания комментария.
/// </summary>
public class CreateCommentDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; } = null!;

    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvertisementId { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int AccountId { get; set; }
}