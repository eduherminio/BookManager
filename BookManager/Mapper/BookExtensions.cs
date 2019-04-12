using BookManager.Dto;
using BookManager.Model;

namespace BookManager.Mapper
{
    /// <summary>
    /// TODO replace with automapper or similar
    /// </summary>
    public static class BookExtensions
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto()
            {
                Author = book.Author,
                ISBN = book.ISBN,
                Title = book.Title,
                Genre = book.Genre
            };
        }

        public static SimpleBookDto ToSimpleBookDto(this Book book)
        {
            return new SimpleBookDto()
            {
                Author = book.Author,
                ISBN = book.ISBN,
                Title = book.Title
            };
        }
    }
}
