using Board.Domain.Advertisement;
using System.Collections.Generic;

namespace Board.Domain.Category;

/// <summary>
/// Категории.
/// </summary>
public class Categories
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор родительской категории.
    /// </summary>
    public int ParentCategoryId { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список объявлений.
    /// </summary>
    public virtual List<Advertisements> AdvertisementsList { get; set; }

}