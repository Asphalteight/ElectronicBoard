namespace Board.Contracts.Contexts.Messages;

/// <summary>
/// Модель создания сообщения.
/// </summary>
public class CreateMessageDto
{
    /// <summary>
    /// Идентификатор отправителя.
    /// </summary>
    public int Sender { get; set; }
    
    /// <summary>
    /// Идентификатор получателя.
    /// </summary>
    public int Reciever { get; set; }
    
    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Дата и время отправки.
    /// </summary>
    public DateTime SentAt { get; set; }
    
    /// <summary>
    /// Прочитано ли.
    /// </summary>
    public bool IsRead { get; set; }
}