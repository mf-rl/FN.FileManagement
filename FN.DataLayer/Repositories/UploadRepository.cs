using FN.DataLayer.Abstractions;
using FN.DataLayer.Contract.Tables;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FN.DataLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FN.DataLayer.Repositories
{
    public class UploadRepository : GenericRepository<Upload>, IUploadRepository
    {
        public UploadRepository(ConnectionDataContext context) : base(context) { }

        /// <summary>
        /// Gets all uploads WITHOUT loading binary file content for performance.
        /// Use GetUploadById to retrieve the full upload with file content.
        /// </summary>
        public async Task<IList<Upload>> GetUploads()
        {
            return await GetIQueryable()
                .Select(u => new Upload
                {
                    Id = u.Id,
                    FileName = u.FileName,
                    Extension = u.Extension,
                    UploadDate = u.UploadDate,
                    FileContent = null // Explicitly exclude binary data
                })
                .ToListAsync();
        }

        public async Task<Upload> GetUploadById(int id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets upload metadata only (without file content) for a specific upload.
        /// Useful when you only need file info, not the actual file bytes.
        /// </summary>
        public async Task<Upload> GetUploadMetadataById(int id, CancellationToken cancellationToken)
        {
            return await GetIQueryable()
                .Where(u => u.Id == id)
                .Select(u => new Upload
                {
                    Id = u.Id,
                    FileName = u.FileName,
                    Extension = u.Extension,
                    UploadDate = u.UploadDate,
                    FileContent = null
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<int> AddUpload(Upload upload, CancellationToken cancellationToken)
        {
            await InsertAsync(upload, cancellationToken, true);
            return upload.Id;
        }

        public async Task DeleteUpload(int id, CancellationToken cancellationToken)
        {
            await DeleteAsync(id, cancellationToken, true);
        }
    }
}
