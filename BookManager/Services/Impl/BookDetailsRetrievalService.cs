using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using BookManager.Http;
using BookManager.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookManager.Services.Impl
{
    public class BookDetailsRetrievalService : IBookDetailsRetrievalService
    {
        private readonly HttpClient _httpClient;

        public BookDetailsRetrievalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Book RetrieveBookInfo(string isbn)
        {
            Uri uri = CreateUri(isbn);
            JObject jObject = HttpRequest.Get<JObject>(_httpClient, uri, out HttpStatusCode statusCode);

            if (statusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(jObject.ToString().Trim('{').Trim('}')))
            {
                return ParseRetrievedInfo(jObject, isbn);
            }
            else
            {
                return null;
            }
        }

        private Book ParseRetrievedInfo(JObject jObject, string isbn)
        {
            string str = jObject.ToString();
            str = str.Replace("\"ISBN:" + isbn + "\": {", "");
            str = str.Remove(str.Length - 1, 1);

            BookInfo info = JsonConvert.DeserializeObject<BookInfo>(str);

            return new Book()
            {
                ISBN = isbn,
                Title = info.Title,
                Author = string.Join(";", info.Authors.Select(author => author.Name))
            };
        }

        private static Uri CreateUri(string str) => new Uri(
            $"https://openlibrary.org/api/books?bibkeys=ISBN:{str}&jscmd=data&format=json", UriKind.Absolute);

        private class BookInfo
        {
            public string Title { get; set; }

            public ICollection<Authors> Authors { get; set; }
        }

        private class Authors
        {
            public string Name { get; set; }
        }
    }
}
