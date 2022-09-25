namespace Academic.Domain.DAL.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity? GetById(object id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
