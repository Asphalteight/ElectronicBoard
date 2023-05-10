using System.ComponentModel.DataAnnotations;

namespace Board.Contracts.Contexts.Accounts;

/// <summary>
/// Модель изменения аккаунта.
/// </summary>
public class UpdateAccountDto
{
    /// <summary>
    /// Имя.
    /// </summary>
    [Required(ErrorMessage = "Не указано имя")]
    [StringLength(50, ErrorMessage = "Имя превышает допустимую длину")]
    public string? Name { get; set; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    [Required(ErrorMessage = "Не указан адрес электронной почты")]
    [RegularExpression(@"^.+\@.+\..+$", ErrorMessage = "Неверный шаблон")]
    public string? Email { get; set; }
    
    /// <summary>
    /// Номер телефона.
    /// </summary>
    [StringLength(15, ErrorMessage = "Номер телефона превышает допустимую длину")]
    public string? Phone { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    [Required(ErrorMessage = "Не указан пароль")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль имеет недопустимую длину")]
    public string? Password { get; set; }
    
    /// <summary>
    /// Идентификатор картинки для аватара.
    /// </summary>
    public Guid? PictureId { get; set; }
}