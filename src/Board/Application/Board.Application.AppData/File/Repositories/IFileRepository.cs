﻿using Board.Contracts.Files;
using Board.Domain.File;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Application.AppData.Context.File.Repositories;

/// <summary>
/// Репозиторий для работы с файлами.
/// </summary>
public interface IFileRepository
{
    /// <summary>
    /// Получение информации о файле по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о файле.</returns>
    Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Загрузка файла в систему.
    /// </summary>
    /// <param name="model">Модель файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Идентификатор загруженного файла.</returns>
    Task<Guid> UploadAsync(Files model, CancellationToken cancellationToken);

    /// <summary>
    /// Скачивание файла.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Информация о скачиваемом файле.</returns>
    Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление файла по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>        
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}