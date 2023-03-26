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
    public int Receiver { get; set; }

    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; } = null!;
}