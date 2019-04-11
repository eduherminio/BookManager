using System;
using System.Collections.Generic;
using System.Text;
using BookManager.Dto;
using BookManager.Model;

namespace BookManager.Services
{
    public interface IBookManagerService
    {
        SimpleBookDto FindByISBN(string id);
        ICollection<SimpleBookDto> LoadAll();
        ICollection<SimpleBookDto> FindByAuthor(string author);
        ICollection<SimpleBookDto> FindByGenre(Genre genre);
        BookDto LoadWithDetails(string id);
        string AddBook(string isbn);
    }
}
