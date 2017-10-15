using MongoDB.Driver;

namespace Restaurant.Database
{
    public static class MongoAuthConnectionFactory
    {
        public static IMongoDatabase MongoDatabase(string databaseName)
        {
            const string mongoConnectionString = "localhost:27017?authSource=admin";
            const string mongoUsername = "demoAdmin";
            const string mongoPassword = "CU*e8Q6O!14b";
            var mongoClient = new MongoClient($"mongodb://{mongoUsername}:{mongoPassword}@{mongoConnectionString}");
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            return mongoDatabase;
        }
    }
}