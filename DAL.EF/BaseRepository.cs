﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Abstract;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public abstract class BaseRepository<TDbContext, TEntity, TEntityId> : IRepository<TEntity, TEntityId>
        where TEntity : class, IEntity<TEntityId>
        where TDbContext : CarsDbContext
    {
        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected TDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        public TEntity Add(TEntity entity, bool save)
        {
            var entityEntry = DbSet.Add(entity);
            TEntity addedEntity = entityEntry.Entity;

            if (save)
            {
                DbContext.SaveChanges();
            }

            return addedEntity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, bool save = true)
        {
            var entityEntry = await DbSet.AddAsync(entity);
            var addedEntity = entityEntry.Entity;

            if (save)
            {
                await DbContext.SaveChangesAsync();
            }

            return addedEntity;
        }


        public void Delete(params TEntityId[] id)
        {
            foreach (TEntityId entityId in id)
            {
                Delete(GetById(entityId));
            }
        }

        public virtual void Delete(params TEntity[] entities)
        {
            DbSet.RemoveRange(entities);
            DbContext.SaveChanges();
        }

        public async Task<TEntity> GetByIdAsync(TEntityId id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Update(entity, true);
        }

        public async Task UpdateAsync(TEntity entity, bool save)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            if (save)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await UpdateAsync(entity, true);
        }

        public virtual void Update(TEntity entity, bool save)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            if (save)
            {
                DbContext.SaveChanges();
            }
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (string includeProperty in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }

            return query.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbContext.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity GetById(TEntityId id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }
    }
}