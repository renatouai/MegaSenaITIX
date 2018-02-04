using System;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Erp.Infra.Base
{
    public interface IUnitOfWork<TContext>
         where TContext : DbContext
    {
        DbContextTransaction BeginTransation();

        bool SaveChanges();
        void AddToContext<T>(T entity)
            where T : class;
        void LoadReference<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> property)
            where TEntity : class
            where TProperty : class;
        TContext Context { get; }
    }
}