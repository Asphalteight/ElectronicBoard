namespace Board.Contracts.Contexts;

/// <summary>
/// Модель для ошибок.
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Код ошибки.
    /// </summary>
    public string ErrorCode { get; set; } = string.Empty;

    /// <summary>
    /// Сообщение для пользователя.
    /// </summary>
    public string UserMessage { get; set; } = string.Empty;

    /// <summary>
    /// Вложенные ошибки.
    /// </summary>
    public ErrorDto[] InternalErrors { get; set; }
}