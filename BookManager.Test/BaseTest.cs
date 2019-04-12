using System;

namespace BookManager.Test
{
    public abstract class BaseTest
    {
        protected const string ExistingISBN = "9780980200447";

        public static string NewGuid() => Guid.NewGuid().ToString();
    }
}
