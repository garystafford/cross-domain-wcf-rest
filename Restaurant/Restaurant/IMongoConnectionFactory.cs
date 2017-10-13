using MongoDB.Driver;

namespace Restaurant
{
    public interface IMongoConnectionFactory
    {
        IMongoDatabase MongoDatabase(string databaseName);
    }
}