using System;
using MongoDB.Driver;

namespace Restaurant
{
    public static class MongoNoAuthConnectionFactory
    {
        public static IMongoDatabase MongoDatabase(string databaseName)
        {
            var mongoClient = new MongoClient($"mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            return mongoDatabase;
        }
    }
}