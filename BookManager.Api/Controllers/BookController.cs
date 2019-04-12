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

        [HttpGet("{id}")]
        public SimpleBookDto Load(string id)
        {
            return _bookManagerService.FindByISBN(id);
        }

        [HttpGet("{id}/details")]
        public BookDto LoadDetailed(string id)
        {
            return _bookManagerService.LoadWithDetails(id);
        }

        [HttpGet]
        public ICollection<SimpleBookDto> LoadAll()
        {
            return _bookManagerService.LoadAll();
        }

        [HttpGet("author/{author}")]
        public ICollection<SimpleBookDto> FindByAuthor(string author)
        {
            return _bookManagerService.FindByAuthor(author);
        }

        [HttpGet("genre/{genre}")]
        public ICollection<SimpleBookDto> FindByGenre(Genre genre)
        {
            return _bookManagerService.FindByGenre(genre);
        }
    }
}