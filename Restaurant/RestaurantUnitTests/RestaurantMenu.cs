using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace RestaurantUnitTests
{
    [TestClass]
    public class RestaurantMenu
    {
        [TestMethod]
        public void Test_RestaurantMenu_DefaultConstructor_HasMutlipleItems()
        {
            var restaurantMenu = new Restaurant.RestaurantMenu();

            Assert.IsTrue(restaurantMenu.Count > 1);
        }

        [TestMethod]
        public void Test_RestaurantMenu_AddOneItem_ItemCountEqualsOne()
        {
            var menuItem = new Restaurant.MenuItem(99, "Test Item", 9.99);
            var menuList = new Collection<MenuItem>();
            menuList.Add(menuItem);
            var restaurantMenu = new Restaurant.RestaurantMenu(menuList);

            Assert.AreEqual(restaurantMenu.Count, 1);
        }
    }
}
