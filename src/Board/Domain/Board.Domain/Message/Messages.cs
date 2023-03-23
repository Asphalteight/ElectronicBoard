namespace Board.Domain.Message;

public class Messages
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Отправитель.
    /// </summary>
    public int Sender { get; set; }
    
    /// <summary>
    /// Получатель.
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