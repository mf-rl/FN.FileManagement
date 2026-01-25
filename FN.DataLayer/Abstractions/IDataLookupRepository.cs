namespace FN.DataLayer.Abstractions
{
    public interface IDataLookupRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class 
    {
    }
}
