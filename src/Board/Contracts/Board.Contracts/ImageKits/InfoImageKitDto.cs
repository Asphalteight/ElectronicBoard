using Board.Domain.Advertisement;

namespace Board.Contracts.ImageKits;

/// <summary>
/// Информация о наборе изображений для объявления.
/// </summary>
public class InfoImageKitDto
{
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvertisementId { get; set; }
    
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