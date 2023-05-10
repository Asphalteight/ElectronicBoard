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
    public string Name { get; set; }

    /// <summary>
    /// Содержимое.
    /// </summary>
    public byte[] Content { get; set; }

    /// <summary>
    /// Тип контента.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Размер файла.
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Дата/время создания (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }
}