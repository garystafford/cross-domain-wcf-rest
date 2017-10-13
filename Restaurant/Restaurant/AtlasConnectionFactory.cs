using System;
using MongoDB.Driver;

namespace Restaurant
{
    public class AtlasConnectionFactory : IMongoConnectionFactory
    {
        public IMongoDatabase MongoDatabase(string databaseName)
        {
            var atlasCluster = Environment.GetEnvironmentVariable("ATLAS_CLUSTER");
            var atlasUsername = Environment.GetEnvironmentVariable("ATLAS_USERNAME");
            var atlasPassword = Environment.GetEnvironmentVariable("ATLAS_PASSWORD");
            var client = new MongoClient($"mongodb://{atlasUsername}:{atlasPassword}@{atlasCluster}");
            var database = client.GetDatabase(databaseName);
            return database;
        }
    }
}