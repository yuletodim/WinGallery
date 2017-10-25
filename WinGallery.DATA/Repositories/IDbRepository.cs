namespace WinGallery.DATA.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDbRepository<TEntity, in TKey> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetAllWithDeleted();

        TEntity Find(TKey id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        TEntity Remove(TKey id);

        void SaveChanges();
    }
}
