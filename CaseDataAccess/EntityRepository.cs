﻿using CaseDataAccess.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess
{
    public class EntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }


        public async Task Update(Expression<Func<TEntity, bool>> filter, TEntity updatedEntity)
        {
            using (var context = new TContext())
            {
                var entityToUpdate = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
                updatedEntity.Id = entityToUpdate.Id;
                context.Entry(entityToUpdate).CurrentValues.SetValues(updatedEntity);
                await context.SaveChangesAsync();

            }
        }

        public async Task Delete(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var deletedEntity = await context.Set<TEntity>().SingleOrDefaultAsync(filter);
                var entity = context.Entry(deletedEntity);
                entity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }


        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }


    }
}
