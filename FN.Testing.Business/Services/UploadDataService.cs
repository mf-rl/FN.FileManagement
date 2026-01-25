using FN.Testing.Business.Contract.Abstractions;
using FN.Testing.Business.Contract.Entities;
using FN.Testing.DataLayer.Contract.Abstractions;
using FN.Testing.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FN.Testing.Common.Mappings;

namespace FN.Testing.Business.Services
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
            if (file != null && new Uploader().DeleteFile(string.Concat(file.FileName, file.Extension)))
            {
                await _repository.DeleteUpload(id, cancellationToken);
            }            
        }
        public async Task<UploadedEntity> AddUpload(UploadEntity entity, CancellationToken cancellationToken)
        {
            var uploadPath = new Uploader().UploadFile(entity.File);
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
            return await new Uploader().DownloadFile(filePath);           
        }
        public string GetContentType(string filePath)
        {
            return new Uploader().GetContentType(filePath);
        }
    }
}
