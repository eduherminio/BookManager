using System.Collections.Generic;
using BookManager.Dto;
using BookManager.Model;

namespace BookManager.Services
{
    public interface IBookManagerService
    {
        /// <summary>
        /// Adds a book to local library, retrieving some details of it from Internet
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        string AddBook(string isbn);

        /// <summary>
        /// Loads a book by its ISBN
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        SimpleBookDto FindByISBN(string isbn);

        /// <summary>
        /// Loads all existing books
        /// </summary>
        /// <returns></returns>
        ICollection<SimpleBookDto> LoadAll();

        /// <summary>
        /// Loads books by its author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        ICollection<SimpleBookDto> FindByAuthor(string author);

        /// <summary>
        /// Loads books by its genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        ICollection<SimpleBookDto> FindByGenre(Genre genre);

        /// <summary>
        /// Loads detailed information of a book
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        BookDto LoadWithDetails(string isbn);
    }
}
