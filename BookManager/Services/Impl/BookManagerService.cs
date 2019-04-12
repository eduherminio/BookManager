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
        private readonly IBookDetailsRetrievalService _bookDetailsRetrievalService;

        public BookManagerService(IBookDao dao, IBookDetailsRetrievalService bookDetailsRetrievalService)
        {
            _dao = dao;
            _bookDetailsRetrievalService = bookDetailsRetrievalService;
        }

        public string AddBook(string isbn)
        {
            Book book = _bookDetailsRetrievalService.RetrieveBookInfo(isbn);

            if (book != null)
            {
                book = _dao.Create(book);
                return book.ISBN;
            }
            else
            {
                throw new EntityDoesNotExistException($"ISBN {isbn} cannot be found");
            }
        }

        public ICollection<SimpleBookDto> FindByAuthor(string author)
        {
            return _dao.FindWhere(book => book.Author.IndexOf(author, StringComparison.InvariantCultureIgnoreCase) >= 0)
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public ICollection<SimpleBookDto> FindByGenre(Genre genre)
        {
            return _dao.FindWhere(book => book.Genre == genre)
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public SimpleBookDto FindByISBN(string isbn)
        {
            Book book = _dao.Load(isbn);
            if (book != null)
            {
                return book.ToSimpleBookDto();
            }
            else
            {
                throw new EntityDoesNotExistException(
                   $"There's no saved book with that ISBN ({isbn}), try adding it");
            }
        }

        public ICollection<SimpleBookDto> LoadAll()
        {
            return _dao.LoadAll()
                .Select(book => book.ToSimpleBookDto()).ToList();
        }

        public BookDto LoadWithDetails(string isbn)
        {
            return _dao.Load(isbn).ToBookDto();
        }
    }
}
