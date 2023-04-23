namespace Board.Domain.File;

/// <summary>
/// Файлы.
/// </summary>
public class Files
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Содержимое.
    /// </summary>
    public byte[] Content { get; set; } = null!;

    /// <summary>
    /// Тип контента.
    /// </summary>
    public string ContentType { get; set; } = null!;

    /// <summary>
    /// Размер файла.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Дата/время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }
}