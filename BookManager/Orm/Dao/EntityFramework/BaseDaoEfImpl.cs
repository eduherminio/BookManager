﻿using Microsoft.EntityFrameworkCore;
using BookManager.Exceptions;
using BookManager.Orm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookManager.Orm.Dao.EntityFramework
{
    /// <summary>
    /// EF Core implementation of IDao. Uses
    /// </summary>
    /// <remarks>
    /// Uses QueryTemplate + BusinessKeyCondition to execute queries in DB
    /// </remarks>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TBusinessKey"></typeparam>
    public abstract class BaseDaoEfImpl<TEntity, TBusinessKey>
        : IDao<TEntity, TBusinessKey> where TEntity : Entity<TBusinessKey>
    {
        protected DbContext Context { get; set; }

        protected BaseDaoEfImpl(IBookManagerContextContainer contextContainer)
        {
            Context = contextContainer.Context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            CreateBusinessKey(entity);
            Context.Add(entity);
            SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            BeforeUpdateEntity(entity);
            SaveChanges();
            return entity;
        }

        public virtual void Delete(TBusinessKey businessKey)
        {
            TEntity entity = Load(businessKey);

            if (entity == null)
            {
                throw new EntityDoesNotExistException("Trying to delete a non existing entity");
            }

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Remove(entity);
            SaveChanges();
        }

        public virtual ICollection<TEntity> LoadAll()
        {
            return new List<TEntity>(QueryTemplate());
        }

        public virtual TEntity Load(TBusinessKey businessKey)
        {
            return QueryTemplate()
                .SingleOrDefault(BusinessKeyCondition(businessKey));
        }

        public virtual ICollection<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return new List<TEntity>(QueryTemplate()
                .Where(predicate));
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return QueryTemplate().Any(predicate);
        }

        /// <summary>
        /// To be overriden in entities not implementing IAutoGeneratedBusinessKey
        /// </summary>
        /// <param name="businessKey"></param>
        /// <returns></returns>
        protected virtual Expression<Func<TEntity, bool>> BusinessKeyCondition(TBusinessKey businessKey)
        {
            return t => ((IAutoGeneratedBusinessKey)t).AutoGeneratedBusinessKey.Equals(businessKey);
        }

        protected virtual IQueryable<TEntity> QueryTemplate()
        {
            return Context.Set<TEntity>();
        }

        protected virtual void CreateBusinessKey(TEntity entity)
        {
            if (entity is IAutoGeneratedBusinessKey entityWithAutoGeneratedId)
            {
                entityWithAutoGeneratedId.AutoGeneratedBusinessKey = Guid.NewGuid().ToString();
            }
        }

        protected virtual void BeforeUpdateEntity(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        private void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
