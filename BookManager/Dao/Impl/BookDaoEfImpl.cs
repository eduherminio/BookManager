using BookManager.Model;
using BookManager.Orm;
using BookManager.Orm.Dao.EntityFramework;
using System;
using System.Linq.Expressions;

namespace BookManager.Dao.Impl
{
    public class BookDaoEfImpl : BaseDaoEfImpl<Book, string>, IBookDao
    {
        protected BookDaoEfImpl(IBookManagerContextContainer contextContainer) : base(contextContainer)
        {
        }

        protected override Expression<Func<Book, bool>> BusinessKeyCondition(string businessKey)
        {
            return t => t.ISBN.Equals(businessKey);
        }
    }
}
