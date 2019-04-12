using BookManager.Api.Test.Utils;
using BookManager.Dao;
using BookManager.Http;
using BookManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace BookManager.Api.Test
{
    [Collection(BookManagerTestCollection.Name)]
    public class BookApiTest
    {
        private readonly Fixture _fixture;

        private const string _bookUri = "api/books";

        public BookApiTest(Fixture fixture) => _fixture = fixture;

        [Fact]
        public void LoadAll()
        {
            // Arrange
            HttpClient client = _fixture.GetClient();
            Uri uri = _fixture.CreateUri(_bookUri);

            // Act
            ICollection<Book> result = HttpRequest.Get<ICollection<Book>>(client, uri, out HttpStatusCode statusCode);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Empty(result);

            // Rearrange
            Book book = new Book() { ISBN = Guid.NewGuid().ToString() };
            _fixture.GetService<IBookDao>().Create(book);

            result = HttpRequest.Get<ICollection<Book>>(client, uri, out statusCode);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(result);
            Assert.Equal(book.ISBN, result.FirstOrDefault()?.ISBN);
        }

        // .etc
    }
}
