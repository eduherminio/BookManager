using System.Collections.Generic;
using BookManager.Dto;
using BookManager.Model;

namespace BookManager.Services
{
    public interface IBookManagerService
    {
        string AddBook(string isbn);

        SimpleBookDto FindByISBN(string isbn);

        ICollection<SimpleBookDto> LoadAll();

        ICollection<SimpleBookDto> FindByAuthor(string author);

        ICollection<SimpleBookDto> FindByGenre(Genre genre);

        BookDto LoadWithDetails(string isbn);
    }
}
