using System.ComponentModel.DataAnnotations;

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
    [Required(ErrorMessage = "Пустой текст сообщения")]
    [StringLength(500, ErrorMessage = "Длина сообщения превышает 500 символов")]
    public string Text { get; set; } = null!;
}