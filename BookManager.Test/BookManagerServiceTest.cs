using BookManager.Dao;
using BookManager.Exceptions;
using BookManager.Model;
using BookManager.Services;
using BookManager.Services.Impl;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace BookManager.Test
{
    public class BookManagerServiceTest : BaseTest
    {
        private readonly Mock<IBookDao> _daoMock;
        private readonly Mock<IBookDetailsRetrievalService> _retrievalMock;
        private readonly IBookManagerService _bookManagerService;

        public BookManagerServiceTest()
        {
            _daoMock = new Mock<IBookDao>();
            _retrievalMock = new Mock<IBookDetailsRetrievalService>();

            _bookManagerService = new BookManagerService(_daoMock.Object, _retrievalMock.Object);
        }

        [Fact]
        public void AddBook()
        {
            // Arrange
            _retrievalMock
                .Setup(mock => mock.RetrieveBookInfo(ExistingISBN))
                .Returns(DefaultBook());

            _daoMock
                .Setup(mock => mock.Create(It.IsAny<Book>()))
                .Returns(new Book() { ISBN = ExistingISBN });

            // Act
            string isbn = _bookManagerService.AddBook(ExistingISBN);

            // Assert
            Assert.Equal(ExistingISBN, isbn);
            _retrievalMock.Verify(m => m.RetrieveBookInfo(ExistingISBN), Times.Once);
            _daoMock.Verify(m => m.Create(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public void ShouldNotAddNotFoundBook()
        {
            // Arrange
            Book nullBook = null;
            _retrievalMock
                .Setup(mock => mock.RetrieveBookInfo(ExistingISBN))
                .Returns(nullBook);

            // Act
            Assert.Throws<EntityDoesNotExistException>(() => _bookManagerService.AddBook(ExistingISBN));

            // Assert
            _retrievalMock.Verify(m => m.RetrieveBookInfo(ExistingISBN), Times.Once);
            _daoMock.Verify(m => m.Create(It.IsAny<Book>()), Times.Never);
        }

        [Fact]
        public void LoadAll()
        {
            // Arrange
            _daoMock
                .Setup(mock => mock.LoadAll())
                .Returns(new List<Book>());

            // Act
            var list = _bookManagerService.LoadAll();

            // Assert
            Assert.Empty(list);
            _daoMock.Verify(mock => mock.LoadAll(), Times.Once);
        }

        [Fact]
        public void FindByAuthor()
        {
            // Arrange
            _daoMock
                .Setup(mock => mock.FindWhere(It.IsAny<Expression<Func<Book, bool>>>()))
                .Returns(new List<Book>());

            // Act
            var list = _bookManagerService.FindByAuthor(NewGuid());

            // Assert
            Assert.Empty(list);
            _daoMock.Verify(mock => mock.FindWhere(It.IsAny<Expression<Func<Book, bool>>>()), Times.Once);
        }

        [Fact]
        public void FindByGenre()
        {
            // Arrange
            _daoMock
                .Setup(mock => mock.FindWhere(It.IsAny<Expression<Func<Book, bool>>>()))
                .Returns(new List<Book>());

            // Act
            var list = _bookManagerService.FindByGenre(Genre.Terror);

            // Assert
            Assert.Empty(list);
            _daoMock.Verify(mock => mock.FindWhere(It.IsAny<Expression<Func<Book, bool>>>()), Times.Once);
        }

        [Fact]
        public void FindByISBN()
        {
            // Arrange
            _daoMock
                .Setup(mock => mock.Load(It.IsAny<string>()))
                .Returns(DefaultBook());

            // Act
            var book = _bookManagerService.FindByISBN(NewGuid());

            // Assert
            Assert.Equal(ExistingISBN, book.ISBN);
            _daoMock.Verify(mock => mock.Load(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldNotFindByISBN()
        {
            // Arrange
            Book nullBook = null;
            _daoMock
                .Setup(mock => mock.Load(It.IsAny<string>()))
                .Returns(nullBook);

            // Act
            Assert.Throws<EntityDoesNotExistException>(() => _bookManagerService.FindByISBN(ExistingISBN));

            // Assert
            _daoMock.Verify(mock => mock.Load(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void LoadWithDetails()
        {
            // Arrange
            Book bookFixture = DefaultBook();
            _daoMock
                .Setup(mock => mock.Load(It.IsAny<string>()))
                .Returns(bookFixture);

            // Act
            var book = _bookManagerService.LoadWithDetails(NewGuid());

            // Assert
            Assert.Equal(bookFixture.ISBN, book.ISBN);
            Assert.Equal(bookFixture.Title, book.Title);
            Assert.Equal(bookFixture.Author, book.Author);
            Assert.Equal(bookFixture.Genre, book.Genre);
            _daoMock.Verify(mock => mock.Load(It.IsAny<string>()), Times.Once);
        }

        private static Book DefaultBook()
        {
            return new Book()
            {
                ISBN = ExistingISBN,
                Genre = Genre.Adventure,
                Author = NewGuid(),
                Title = NewGuid()
            };
        }
    }
}
