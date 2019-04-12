using BookManager.Orm.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Model
{
    public class Book : Entity<string>
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public Genre Genre { get; set; }

        public override string GetBusinessKey() => ISBN;

        [NotMapped]
        public Borrowing Borrowing { get; set; }
    }
}
