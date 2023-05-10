using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Context.File.Repositories;
using Board.Contracts.Files;
using Board.Domain.File;
using Board.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.File.Repository
{
    /// <inheritdoc cref="IFileRepository"/>
    public class FileRepository : IFileRepository
    {
        private readonly IRepository<Files> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализация экземпляра <see cref="FileRepository"/>.
        /// </summary>
        public FileRepository(IRepository<Files> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdAsync(id, cancellationToken);
            if (file == null)
            {
                return;
            }

            await _repository.DeleteAsync(file, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileDto?> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileInfoDto?> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Guid> UploadAsync(Files model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            
            return model.Id;
        }
    }
}
