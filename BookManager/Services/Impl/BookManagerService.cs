using System;
using System.Collections.Generic;
using System.Linq;
using BookManager.Dao;
using BookManager.Dto;
using BookManager.Exceptions;
using BookManager.Logs;
using BookManager.Mapper;
using BookManager.Model;

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

        public string AddBook(string isbn)
        {
            throw new NotImplementedException();
        }

        public ICollection<SimpleBookDto> FindByAuthor(string author)
        {
            return _dao.FindWhere(book => book.Author == author)
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public ICollection<SimpleBookDto> FindByGenre(Genre genre)
        {
            return _dao.FindWhere(book => book.Genre == genre)
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public SimpleBookDto FindByISBN(string id)
        {
            return _dao.Load(id).ToSimpleBookDto();
        }

        public ICollection<SimpleBookDto> LoadAll()
        {
            return _dao.LoadAll()
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public BookDto LoadWithDetails(string id)
        {
            throw new NotImplementedException();
        }
    }
}
