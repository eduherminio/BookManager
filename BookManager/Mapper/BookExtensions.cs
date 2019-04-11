using BookManager.Dto;
using BookManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManager.Mapper
{
    /// <summary>
    /// TODO replace with automapper
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
