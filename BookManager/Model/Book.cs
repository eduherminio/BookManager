using BookManager.Orm.Model;

namespace BookManager.Model
{
    public class Book : Entity<string>
    {
        public string ISBN { get; set; }

        public override string GetBusinessKey() => ISBN;
    }
}
