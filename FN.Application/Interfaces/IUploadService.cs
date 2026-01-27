using FN.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Application.Interfaces
{
    public interface IUploadService
    {
        Task<UploadedModel> GetUpload(int id, CancellationToken cancellationToken);
        Task<IEnumerable<UploadedModel>> GetUploads(CancellationToken cancellationToken);
        Task<UploadedModel> PostUpload(UploadModel uploadModel, CancellationToken cancellationToken);
        Task DeleteUpload(int id, CancellationToken cancellationToken);
        Task<byte[]> GetFile(int id, CancellationToken cancellationToken);
        string GetContentType(string filePath);
    }
}
