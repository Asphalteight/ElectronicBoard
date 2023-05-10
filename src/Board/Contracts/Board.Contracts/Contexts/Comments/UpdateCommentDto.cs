using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель изменения комментария.
/// </summary>
public class UpdateCommentDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    [Required(ErrorMessage = "Пустой текст комментария")]
    [StringLength(500, ErrorMessage = "Длина комментария превышает 500 символов")]
    public string? Text { get; set; }
}