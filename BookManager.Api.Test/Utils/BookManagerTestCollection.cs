using Xunit;

namespace BookManager.Api.Test.Utils
{
    /// <summary>
    /// Test group definition class.
    /// </summary>
    [CollectionDefinition(Name)]
    public class BookManagerTestCollection : ICollectionFixture<Fixture>
    {
        public const string Name = "BookManagerTestCollection";
    }
}
