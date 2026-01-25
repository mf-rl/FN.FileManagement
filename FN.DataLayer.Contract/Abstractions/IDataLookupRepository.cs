namespace FN.DataLayer.Contract.Abstractions
{
    public interface IDataLookupRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
    }
}
