using Microsoft.EntityFrameworkCore;

namespace BookManager.Orm
{
    public class BookManagerContextContainer<TContext> : IBookManagerContextContainer
        where TContext : DbContext
    {
        public DbContext Context { get; private set; }

        public BookManagerContextContainer(TContext context)
        {
            Context = context;
        }
    }
}
