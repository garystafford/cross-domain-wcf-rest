using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantTests
{
    [TestClass]
    public class MongoDbTestTests
    {
        [TestMethod]
        public void TestMongoTest()
        {
            var mongoDbTest = new MongoDbTest();
            //var list = new Task<List<MenuItem>>(() => new List<MenuItem>());
            //Assert.AreNotSame(list, mongoDbTest.TestMongo());
            var foo = mongoDbTest.TestMongo();
            foreach (var f in foo.Result)
                Console.WriteLine($"{f.Id} {f.Description}");
        }
    }
}