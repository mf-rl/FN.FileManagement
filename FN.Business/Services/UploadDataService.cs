using FN.Business.Abstractions;
using FN.Common.Mappings;
using FN.DataLayer.Abstractions;
using FN.Entities;
using FN.Functions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Business.Services
{
    public class UploadDataService : IUploadDataService
    {
        private readonly IUploadRepository _repository;
        private readonly CustomConfig _customConfig;

        public UploadDataService(
            IUploadRepository repository, IOptions<CustomConfig> customConfig)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            _customConfig = customConfig?.Value ?? throw new ArgumentNullException(nameof(customConfig));
        }
        public async Task<UploadedEntity> GetUpload(int id, CancellationToken cancellationToken)
        {
            var row = await _repository.GetUploadMetadataById(id, cancellationToken);
            return row.ToUploadedEntity();
        }
        public async Task<IEnumerable<UploadedEntity>> GetUploads(CancellationToken cancellationToken)
        {
            var rows = await _repository.GetUploads();
            return rows.ToUploadedEntities();
        }
        public async Task DeleteUpload(int id, CancellationToken cancellationToken)
        {
            var file = await GetUpload(id, cancellationToken);
            if (file != null && Uploader.DeleteFile(string.Concat(file.FileName, file.Extension)))
            {
                await _repository.DeleteUpload(id, cancellationToken);
            }            
        }
        public async Task<UploadedEntity> AddUpload(UploadEntity entity, CancellationToken cancellationToken)
        {
            if (entity?.File == null || entity.File.Length == 0)
                throw new InvalidOperationException("Uploaded file is empty.");

            if (_customConfig.UploadToFileSystem) _ = Uploader.UploadFile(
                entity.File, _customConfig.UploadPath, 
                new UploadProperties { 
                    WidthPercent = _customConfig.WidthPercent, 
                    HeightPercent = _customConfig.HeightPercent, 
                    AllowedSize = _customConfig.AllowedSize 
                });

            var inputEt = await entity.ToNewUploadAsync(cancellationToken);
            return new UploadedEntity
            {
                Id = await _repository.AddUpload(inputEt, cancellationToken),
                Extension = inputEt.Extension, FileName = inputEt.FileName, UploadDate = inputEt.UploadDate
            };
        }
        public async Task<byte[]> GetFile(int id, CancellationToken cancellationToken)
        {
            var row = await _repository.GetUploadById(id, cancellationToken);
            var file = row.ToDownloadEntity().FileContent;
            return file;
        }
        public string GetContentType(string filePath)
        {
            return Uploader.GetContentType(filePath);
        }
    }
}
