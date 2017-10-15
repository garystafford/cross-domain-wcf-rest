using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Models;
using System.Collections.ObjectModel;

namespace RestaurantUnitTests
{
    [TestClass]
    public class RestaurantMenu
    {
        [TestMethod]
        public void Test_RestaurantMenu_DefaultConstructor_ReturnsMutlipleMenuItems()
        {
            Restaurant.RestaurantMenu.BuildMenu();
            var restaurantMenu = Restaurant.RestaurantMenu.GetMenu();
            Assert.IsTrue(restaurantMenu.Count > 0);
        }

        [TestMethod]
        public void Test_RestaurantMenu_AddOneItem_ItemCountEqualsOne()
        {
            var menuItem = new MenuItem("Test Item", 9.99);
            var menuList = new Collection<MenuItem> {menuItem};
            var restaurantMenu = new Menu(menuList);
            Assert.AreEqual(restaurantMenu.Count, 1);
        }
    }
}