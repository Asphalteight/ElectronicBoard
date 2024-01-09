using System;
namespace Board.Contracts.Contexts.Messages;

/// <summary>
/// Информация о личном сообщениии.
/// </summary>
public class InfoMessageDto
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