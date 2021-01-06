using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;

namespace DAL.Abstract
{
    public interface IRepository<TEntity, in TEntityId> where TEntity : IEntity<TEntityId>
    {
        TEntity Add(TEntity entity, bool save = true);
        Task<TEntity> AddAsync(TEntity entity, bool save = true);
        
        void Delete(params TEntityId[] id);
        void Delete(params TEntity[] entities);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();

        TEntity GetById(TEntityId id);
        Task<TEntity> GetByIdAsync(TEntityId id);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, bool save);
        Task UpdateAsync(TEntity entity);
        
        void Update(TEntity entity, bool save);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : IEntity<long>
    {
    }
}