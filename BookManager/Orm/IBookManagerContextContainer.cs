using Microsoft.EntityFrameworkCore;

namespace BookManager.Orm
{
    /// <summary>
    /// Wrapper around Microsoft.EntityFrameworkCore0.DbContext, making easier the use of DI.
    /// </summary>
    public interface IBookManagerContextContainer
    {
        DbContext Context { get; }
    }
}
