using BookManager.Orm.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookManager.Orm.Dao
{
    /// <summary>
    /// Generic Data Access Object
    /// </summary>
    /// <typeparam name="TEntity">Entity<typeparamref name="TBusinessKey"/></typeparam>
    /// <typeparam name="TBusinessKey"></typeparam>
    public interface IDao<TEntity, TBusinessKey>
        where TEntity : Entity<TBusinessKey>
    {
        /// <summary>
        /// Create entry in the database
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns></returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Update entity in the database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Delete entity in the Database
        /// </summary>
        /// <param name="entity">entity to delete</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete entity by BusinessKey
        /// </summary>
        /// <param name="businessKey">Entity BusinessKey</param>
        void Delete(TBusinessKey businessKey);

        /// <summary>
        /// Load by BusinessKey. Returns null if it does not exist
        /// </summary>
        /// <param name="businessKey">Entity BusinessKey</param>
        /// <returns></returns>
        TEntity Load(TBusinessKey businessKey);

        /// <summary>
        /// Load all entities
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> LoadAll();

        /// <summary>
        /// Load all entities which fullfil a given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        ICollection<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Returns if there is any entity that satisfies the condition of the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
