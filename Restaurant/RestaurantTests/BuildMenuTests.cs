using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantTests
{
    [TestClass]
    public class BuildMenuTests
    {
        [TestMethod]
        public void BuildMenuTest()
        {
            RestaurantMenu.BuildMenu();

            //Assert.Fail();
        }
    }
}