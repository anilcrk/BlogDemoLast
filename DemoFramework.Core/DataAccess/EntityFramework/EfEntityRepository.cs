using DemoFramework.Core.Entities;
using DemoFramework.Core.ErrorManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            TEntity result = new TEntity();
            HandleException.ExceptionThrow(() => {
                using (var context=new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                    result = entity;
            }
            });
            return result;
        }

        public void Delete(TEntity entity)
        {
            HandleException.ExceptionThrow(() => {
                using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            });
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            TEntity result=new TEntity();
            HandleException.ExceptionThrow(() => {
                using (var context = new TContext())
                {
                    result = context.Set<TEntity>().SingleOrDefault(filter);
                }
                
            });
            return result;
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            TEntity result = new TEntity();
            HandleException.ExceptionThrow(() => {
                using (var context=new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                result = entity;
            }
            });
            return result;
        }
    }
}
