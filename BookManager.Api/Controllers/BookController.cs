using System.Collections.Generic;
using BookManager.Dto;
using BookManager.Model;
using BookManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookManagerService _bookManagerService;

        public BookController(IBookManagerService bookManagerService)
        {
            _bookManagerService = bookManagerService;
        }

        /// <summary>
        /// Adds a book the collection
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpPost("{isbn}")]
        public string Add(string isbn)
        {
            return _bookManagerService.AddBook(isbn);
        }

        /// <summary>
        /// Loads information of a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public SimpleBookDto Load(string id)
        {
            return _bookManagerService.FindByISBN(id);
        }

        /// <summary>
        /// Loads detailed information of a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/details")]
        public BookDto LoadDetailed(string id)
        {
            return _bookManagerService.LoadWithDetails(id);
        }

        /// <summary>
        /// Loads all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ICollection<SimpleBookDto> LoadAll()
        {
            return _bookManagerService.LoadAll();
        }

        /// <summary>
        /// Loads all books written by a certain author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet("author/{author}")]
        public ICollection<SimpleBookDto> FindByAuthor(string author)
        {
            return _bookManagerService.FindByAuthor(author);
        }

        /// <summary>
        /// Loads all books of a certain genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpGet("genre/{genre}")]
        public ICollection<SimpleBookDto> FindByGenre(Genre genre)
        {
            return _bookManagerService.FindByGenre(genre);
        }
    }
}
