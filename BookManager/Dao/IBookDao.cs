using BookManager.Model;
using BookManager.Orm.Dao;

namespace BookManager.Dao
{
    public interface IBookDao : IDao<Book, string>
    {
    }
}
