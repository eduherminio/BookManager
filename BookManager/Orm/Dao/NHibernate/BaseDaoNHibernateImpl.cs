using BookManager.Orm.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookManager.Orm.Dao.NHibernate
{
    public abstract class BaseDaoNHibernateImpl<TEntity, TBusinessKey>
        : IDao<TEntity, TBusinessKey> where TEntity : Entity<TBusinessKey>
    {
        public abstract bool Any(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity Create(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void Delete(TBusinessKey businessKey);
        public abstract void Delete(ICollection<TBusinessKey> listBusinessKey);
        public abstract ICollection<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity Load(TBusinessKey businessKey);
        public abstract ICollection<TEntity> LoadAll();
        public abstract TEntity Update(TEntity entity);
    }
}
