using BookManager.Model;
using BookManager.Services;
using BookManager.Services.Impl;
using System.Net.Http;
using Xunit;

namespace BookManager.Test
{
    public class BookDetailsRetrievalServiceTest : BaseTest
    {
        [Fact]
        public void RetrieveBook()
        {
            // Arrange
            Book expectedBook = new Book()
            {
                ISBN = ExistingISBN,
                Title = "Slow reading",
                Author = "John Miedema"
            };

            IBookDetailsRetrievalService service = new BookDetailsRetrievalService(new HttpClient());

            // Act
            Book retrievedBook = service.RetrieveBookInfo(expectedBook.ISBN);

            // Assert
            Assert.Equal(expectedBook.ISBN, retrievedBook.ISBN);
            Assert.Equal(expectedBook.Title, retrievedBook.Title);
            Assert.Equal(expectedBook.Author, retrievedBook.Author);
        }

        [Fact]
        public void ShouldNotRetrieveBook()
        {
            IBookDetailsRetrievalService service = new BookDetailsRetrievalService(new HttpClient());

            Assert.Null(service.RetrieveBookInfo(NewGuid()));
        }
    }
}
