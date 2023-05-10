using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель создания аккаунта.
/// </summary>
public class CreateAccountDto
{
    /// <summary>
    /// Имя.
    /// </summary>
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(50, ErrorMessage = "Имя превышает допустимую длину")]
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    [Required(ErrorMessage = "Не указан адрес электронной почты")]
    [RegularExpression(@"^.+\@.+\..+$", ErrorMessage = "Неверный шаблон")]
    [StringLength(320, ErrorMessage = "Адрес электронной почты превышает допустимую длину")]
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// Номер телефона.
    /// </summary>
    [StringLength(15, ErrorMessage = "Номер телефона превышает допустимую длину")]
    public string? Phone { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    [Required(ErrorMessage = "Не указан пароль")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль имеет недопустимую длину")]
    public string Password { get; set; } = null!;
    
    /// <summary>
    /// Идентификатор картинки для аватара.
    /// </summary>
    public Guid? PictureId { get; set; }
}