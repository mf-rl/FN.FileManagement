using FN.Business.Contract.Abstractions;
using FN.Business.Contract.Entities;
using FN.DataLayer.Contract.Abstractions;
using FN.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FN.Common.Mappings;

namespace FN.Business.Services
{
    public class UploadDataService : IUploadDataService
    {
        private readonly IUploadRepository _repository;

        public UploadDataService(
            IUploadRepository repository)
        {
            _repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }
        public async Task<UploadedEntity> GetUpload(int id, CancellationToken cancellationToken)
        {
            var row = await _repository.GetUploadById(id, cancellationToken);
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
            var uploadPath = Uploader.UploadFile(entity.File);
            var inputEt = entity.ToUpload();
            inputEt.UploadDate = DateTime.Now;
            inputEt.Id = 0;
            inputEt.FileName = Path.GetFileNameWithoutExtension(uploadPath);
            inputEt.Extension = Path.GetExtension(uploadPath);
            return new UploadedEntity
            {
                Id = await _repository.AddUpload(inputEt, cancellationToken),
                Extension = inputEt.Extension, FileName = inputEt.FileName, UploadDate = inputEt.UploadDate
            };
        }
        public async Task<byte[]> GetFile(string filePath, CancellationToken cancellationToken)
        {
            return await Uploader.DownloadFile(filePath);           
        }
        public string GetContentType(string filePath)
        {
            return Uploader.GetContentType(filePath);
        }
    }
}
