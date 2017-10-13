using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;
using Restaurant.Models;

namespace RestaurantUnitTests
{
    [TestClass]
    public class RestaurantMenu
    {
        [TestMethod]
        public void Test_RestaurantMenu_DefaultConstructor_ReturnsMutlipleMenuItems()
        {
            var restaurantMenu = new Restaurant.Models.Menu();
            Assert.IsTrue(restaurantMenu.Count > 1);
        }

        [TestMethod]
        public void Test_RestaurantMenu_AddOneItem_ItemCountEqualsOne()
        {
            var menuItem = new MenuItem("Test Item", 9.99);
            var menuList = new Collection<MenuItem> {menuItem};
            var restaurantMenu = new Restaurant.Models.Menu(menuList);
            Assert.AreEqual(restaurantMenu.Count, 1);
        }
    }
}