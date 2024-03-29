﻿using Board.Domain.Account;
using Board.Domain.Advertisement;
using System;

namespace Board.Domain.Comment;

/// <summary>
/// Комментарии.
/// </summary>
public class Comments
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Текст.
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Дата и время создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Идентификатор объявления.
    /// </summary>
    public int AdvertisementId { get; set; }
    
    /// <summary>
    /// Объявление.
    /// </summary>
    public virtual Advertisements Advertisement { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Пользователь.
    /// </summary>
    public virtual Accounts Account { get; set; }
}