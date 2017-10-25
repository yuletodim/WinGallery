namespace WinGallery.DATA.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using WinGallery.DATA.Models.CommonLogic;

    public class DbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey> where TEntity : class, IAuditInfo, IDeletableEntity
    {
        public DbRepository(DbContext context)
        {
            if(context == null)
            {
                throw new ArgumentException("An instance of  DbRepository is necessary to use this repository.", nameof(context));
            }

            this.Context = context;
            this.EntitySet = this.Context.Set<TEntity>();
        }

        private DbContext Context { get; }

        public IDbSet<TEntity> EntitySet { get; }

        public TEntity Add(TEntity entity)
        {
            return this.ChangeState(entity, EntityState.Added);
        }

        public TEntity Find(TKey id)
        {
            return this.EntitySet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            return this.ChangeState(entity, EntityState.Modified);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.EntitySet.Where(e => e.IsDeleted == false);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.EntitySet.Where(e => e.IsDeleted == false).ToListAsync();
        }

        public IQueryable<TEntity> GetAllWithDeleted()
        {
            return this.EntitySet;
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public TEntity Remove(TKey id)
        {
            var entity = this.Find(id);
            this.Remove(entity);

            return entity;
        }

        public void SetAsDeleted(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        private TEntity ChangeState(TEntity entity, EntityState state)
        {
            // Get entry from the context for this entity
            var entry = this.Context.Entry(entity);

            // If entry state is detached => atach entity to entity set
            if(entry.State == EntityState.Detached)
            {
                this.EntitySet.Attach(entity);
            }

            // Chenge state of the entry and return entity
            entry.State = state;

            return entity;
        }
    }
}
