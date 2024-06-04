namespace SingletonPattern;

[CollectionDefinition((CollectionName))]
public class SingletonTestCollection : ICollectionFixture<SingletonTest>
{
    private const string CollectionName = "SingletonTestsCollection";
}