using FN.DataLayer.Contract.Abstractions;
using FN.DataLayer.Contract.Tables;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FN.DataLayer.DataContext;

namespace FN.DataLayer.Repositories
{
    public class UploadRepository : GenericRepository<Upload>, IUploadRepository
    {
        public UploadRepository(ConnectionDataContext context) : base (context) { }
        public async Task<IList<Upload>> GetUploads()
        {
            return await GetAllAsync();
        }
        public async Task<Upload> GetUploadById(int id, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(id, cancellationToken);
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
