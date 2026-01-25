using FluentValidation;
using FN.Testing.Application.Contract.Models;
using FN.Testing.Application.Contract.Services;
using FN.Testing.Business.Contract.Abstractions;
using FN.Testing.Common.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FN.Testing.Business.Mappings;
using FN.Testing.Common.Mappings;

namespace FN.Testing.Application.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadDataService _uploadDataService;
        private readonly IValidator<UploadModel> _validator;
        public UploadService(
            IUploadDataService uploadDataService,
            IValidator<UploadModel> validator
            )
        {
            _uploadDataService = uploadDataService ?? throw new System.ArgumentNullException(nameof(uploadDataService));
            _validator = validator;
        }
        public async Task<UploadedModel> GetUpload(int id, CancellationToken cancellationToken)
        {
            var result = await _uploadDataService.GetUpload(id, cancellationToken);
            return result.ToUploadedModel();
        }
        public async Task<IEnumerable<UploadedModel>> GetUploads(CancellationToken cancellationToken)
        {
            var result = await _uploadDataService.GetUploads(cancellationToken);
            return result.ToUploadedModels();
        }
        public async Task<UploadedModel> PostUpload(UploadModel uploadModel, CancellationToken cancellationToken)
        {
            _validator.ValidateCustom(uploadModel);
            var result = await _uploadDataService.AddUpload(uploadModel.ToUploadEntity(), cancellationToken);
            return result.ToUploadedModel();
        }
        public async Task DeleteUpload(int id, CancellationToken cancellationToken)
        {
            await _uploadDataService.DeleteUpload(id, cancellationToken);
        }
        public async Task<byte[]> GetFile(string filePath, CancellationToken cancellationToken)
        {
            return await _uploadDataService.GetFile(filePath, cancellationToken);
        }
        public string GetContentType(string filePath)
        {
            return _uploadDataService.GetContentType(filePath);
        }
    }
}
