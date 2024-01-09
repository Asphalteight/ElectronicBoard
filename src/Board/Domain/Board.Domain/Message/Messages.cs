using System;

namespace Board.Domain.Message;

/// <summary>
/// Личные сообщения.
/// </summary>
public class Messages
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
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