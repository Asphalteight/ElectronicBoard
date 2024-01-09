using AutoMapper;
using Board.Application.AppData.Context.File.Repositories;
using Board.Contracts.Files;
using Board.Domain.File;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Board.Application.AppData.Context.File.Services;

/// <inheritdoc/>
public class FileService : IFileService
{
    private readonly IFileRepository _fileRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализация экземпляра <see cref="FileService"/>.
    /// </summary>        
    public FileService(IFileRepository fileRepository, IMapper mapper)
    {
        _fileRepository = fileRepository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _fileRepository.DeleteAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken)
    {
        return _fileRepository.DownloadAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _fileRepository.GetInfoByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<Guid> UploadAsync(FileDto model, CancellationToken cancellationToken)
    {
        var file = _mapper.Map<FileDto, Files>(model);
        
        return _fileRepository.UploadAsync(file, cancellationToken);
    }
}