using FN.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FN.Business.Abstractions
{
    public interface IUploadDataService
    {
        Task<UploadedEntity> GetUpload(int id, CancellationToken cancellationToken);
        Task<IEnumerable<UploadedEntity>> GetUploads(CancellationToken cancellationToken);
        Task<UploadedEntity> AddUpload(UploadEntity entity, CancellationToken cancellationToken);
        Task DeleteUpload(int id, CancellationToken cancellationToken);
        Task<byte[]> GetFile(int id, CancellationToken cancellationToken);
        string GetContentType(string filePath);
    }
}
