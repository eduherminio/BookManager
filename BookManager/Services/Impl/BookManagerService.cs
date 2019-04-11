using BookManager.Dao;
using BookManager.Exceptions;
using BookManager.Logs;

namespace BookManager.Services.Impl
{
    [Log]
    [ExceptionManagement]
    public class BookManagerService : IBookManagerService
    {
        private readonly IBookDao _dao;

        public BookManagerService(IBookDao dao)
        {
            _dao = dao;
            _dao.LoadAll();
        }
    }
}
