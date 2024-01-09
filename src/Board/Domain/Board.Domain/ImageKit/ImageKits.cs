using Board.Domain.Advertisement;
using System;

namespace Board.Domain.ImageKit;

/// <summary>
/// Наборы изображений для объявлений.
/// </summary>
public class ImageKits
{
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvertisementId { get; set; }
    
    /// <summary>
    /// Объявление.
    /// </summary>
    public Advertisements Advertisement { get; set; }
    
    /// <summary>
    /// Идентификатор главного изображения.
    /// </summary>
    public Guid FirstImageId { get; set; }
    
    /// <summary>
    /// Идентификатор второго изображения.
    /// </summary>
    public Guid SecondImageId { get; set; }
    
    /// <summary>
    /// Идентификатор третьего изображения.
    /// </summary>
    public Guid ThirdImageId { get; set; }
}