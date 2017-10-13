using System;
using MongoDB.Driver;

namespace Restaurant
{
    public class MongoNoAuthConnectionFactory : IMongoConnectionFactory
    {
        public IMongoDatabase MongoDatabase(string databaseName)
        {
            var client = new MongoClient($"mongodb://localhost:27017");
            var database = client.GetDatabase(databaseName);
            return database;
        }
    }
}