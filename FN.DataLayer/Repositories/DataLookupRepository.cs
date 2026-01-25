using FN.DataLayer.Contract.Abstractions;
using FN.DataLayer.DataContext;

namespace FN.DataLayer.Repositories
{
    public class DataLookupRepository<TEntity> : GenericRepository<TEntity>, IDataLookupRepository<TEntity> where TEntity : class
    {
        public DataLookupRepository(ConnectionDataContext context) : base(context)
        {

        } 
    }
}
