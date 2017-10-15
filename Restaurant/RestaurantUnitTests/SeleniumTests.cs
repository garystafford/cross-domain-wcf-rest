using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestaurantUnitTests.Properties;

namespace RestaurantUnitTests
{
    [TestClass]
    public class SeleniumTests : IDisposable
    {
        //private readonly IWebDriver _webDriver = new ChromeDriver();
        private static readonly string RestaurantSite = Settings.Default.SiteUrl;

        private IWebDriver _webDriver;

        [TestInitialize]
        public void Initialize()
        {
            _webDriver = new ChromeDriver(Settings.Default.CromeDriverLocation);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Navigate().GoToUrl(RestaurantSite);
        }

        [TestMethod]
        public void Test_PageTitle_IsExpectedString()
        {
            const string expectedPageTitle = "Restaurant Menu Order Demo - Production Version";
            var actualPageTitle = _webDriver.Title;
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [TestMethod]
        public void Test_OnPageTitle_IsExpectedString()
        {
            const string expectedOnPageTitle = "The .NET Diner";
            var actualOnPageTitle = _webDriver.FindElement(By.ClassName("h3"));
            Assert.AreEqual(expectedOnPageTitle, actualOnPageTitle.Text);
        }

        [TestMethod]
        public void Test_MenuItemsCount_IsExpectedInteger()
        {
            const int expectedMenuItemsCount = 10;
            var webElement = _webDriver.FindElement(By.Id("select_item"));
            var actualMenuItems = webElement.FindElements(By.TagName("option"));
            Assert.AreEqual(expectedMenuItemsCount, actualMenuItems.Count);
        }

        [TestMethod]
        public void Test_ClickAddButtonWithNoItem_AddsNoItemsToOrder()
        {
            const int expectedOrderRowCount = 0;
            var webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"order_cart\"]/tbody"));
            var actualOrderRows = webElement.FindElements(By.TagName("tr"));
            Assert.AreEqual(expectedOrderRowCount, actualOrderRows.Count);
        }

        [TestMethod]
        public void Test_ClickOrderButtonWithNoItems_DisplaysError()
        {
            const string expectedMessageTitle = "Error";
            var webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]/p"));
            var actualMessageTitle = webElement.Text;
            Assert.AreEqual(expectedMessageTitle, actualMessageTitle);
        }


        [TestMethod]
        public void Test_ClickOrderButtonWithNoItems_DisplaysExpectedMessage()
        {
            const string expectedMessage = "Your order is empty.";
            var webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]"));
            var actualMessage = webElement.Text;
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        [TestMethod]
        public void Test_AddOneItemToOrder_AddsOneItemToOrder()
        {
            const int expectedRowCount = 1;
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"order_cart\"]/tbody"));
            var actualOrderRows = webElement.FindElements(By.TagName("tr"));
            Assert.AreEqual(expectedRowCount, actualOrderRows.Count);
        }

        [TestMethod]
        public void Test_AddItemToOrder_ClearsSelectedQuantity()
        {
            const int expectedQuantityValueLength = 0;
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("select_quantity"));
            var actualQuantity = webElement.Text;
            Assert.AreEqual(expectedQuantityValueLength, actualQuantity.Length);
        }

        [TestMethod]
        public void Test_AddItemToOrder_ClearsSelectedMenuItem()
        {
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[1]"));
            Assert.IsTrue(webElement.Selected);
        }

        [TestMethod]
        public void Test_ClickOrderButtonWithOneItem_DisplaysConfirmation()
        {
            const string expectedMessageTitle = "Confirmation";
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]/p"));
            var actualMessageTitle = webElement.Text;
            Assert.AreEqual(expectedMessageTitle, actualMessageTitle);
        }

        [TestMethod]
        public void Test_ClickOrderButtonWithOneItem_DisplaysExpectedMessage()
        {
            const string expectedMessage = "Message: Thank you for your order.";
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]"));
            var actualMessage = webElement.Text;
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        public void Dispose()
        {
            _webDriver?.Dispose();
        }
    }
}