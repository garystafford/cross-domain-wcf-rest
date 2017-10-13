using System;
using MongoDB.Driver;

namespace Restaurant
{
    public class MongoAuthConnectionFactory : IMongoConnectionFactory
    {
        public IMongoDatabase MongoDatabase(string databaseName)
        {
            const string mongoConnectionString = "localhost:27017?authSource=admin";
            const string mongoUsername = "demoAdmin";
            const string mongoPassword = "CU*e8Q6O!14b";
            var client = new MongoClient($"mongodb://{mongoUsername}:{mongoPassword}@{mongoConnectionString}");
            var database = client.GetDatabase(databaseName);
            return database;
        }
    }
}