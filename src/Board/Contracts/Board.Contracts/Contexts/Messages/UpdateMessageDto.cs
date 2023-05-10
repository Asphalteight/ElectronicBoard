using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Messages;

/// <summary>
/// Модель изменения сообщения.
/// </summary>
public class UpdateMessageDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    [Required(ErrorMessage = "Пустой текст сообщения")]
    [StringLength(500, ErrorMessage = "Длина сообщения превышает 500 символов")]
    public string? Text { get; set; }

    /// <summary>
    /// Прочитано ли сообщение.
    /// </summary>
    public bool IsRead { get; set; }
}