namespace Board.Contracts.Contexts.Messages;

/// <summary>
/// Модель изменения сообщения.
/// </summary>
public class UpdateMessageDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Прочитано ли.
    /// </summary>
    public bool IsRead { get; set; }
}