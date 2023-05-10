namespace Board.Contracts.ImageKits;

/// <summary>
/// Модель обновления набора изображений для объявления.
/// </summary>
public class UpdateImageKitDto
{
    /// <summary>
    /// Идентификатор главного изображения.
    /// </summary>
    public Guid? FirstImageId { get; set; }
    
    /// <summary>
    /// Идентификатор второго изображения.
    /// </summary>
    public Guid? SecondImageId { get; set; }
    
    /// <summary>
    /// Идентификатор третьего изображения.
    /// </summary>
    public Guid? ThirdImageId { get; set; }
}