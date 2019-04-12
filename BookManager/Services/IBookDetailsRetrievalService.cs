using BookManager.Model;

namespace BookManager.Services
{
    public interface IBookDetailsRetrievalService
    {
        Book RetrieveBookInfo(string isbn);
    }
}
