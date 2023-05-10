using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Comments;

/// <summary>
/// Модель создания комментария.
/// </summary>
public class CreateCommentDto
{
    /// <summary>
    /// Текст.
    /// </summary>
    [Required(ErrorMessage = "Пустой текст комментария")]
    [StringLength(500, ErrorMessage = "Длина комментария превышает 500 символов")]
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