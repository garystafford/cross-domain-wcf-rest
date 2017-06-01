using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RestaurantUnitTests
{
    [TestClass]
    public class SeleniumTests : IDisposable
    {
        //private readonly IWebDriver _webDriver = new ChromeDriver("C:\\chromedriver_win32\\");
        private readonly IWebDriver _webDriver = new ChromeDriver();
        private static readonly string RestaurantSite = Properties.Settings.Default.SiteUrl;

        [TestMethod]
        public void Test_PageTitle_IsExpectedString()
        {
            const string expectedPageTitle = "Restaurant Menu Order Demo - Production Version";
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var actualPageTitle = _webDriver.Title;
            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

        [TestMethod]
        public void Test_OnPageTitle_IsExpectedString()
        {
            const string expectedOnPageTitle = "The .NET Diner";
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var actualOnPageTitle = _webDriver.FindElement(By.ClassName("h3"));
            Assert.AreEqual(expectedOnPageTitle, actualOnPageTitle.Text);
        }

        [TestMethod]
        public void Test_MenuItemsCount_IsExpectedInteger()
        {
            const int expectedMenuItemsCount = 11;
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var webElement = _webDriver.FindElement(By.Id("select_item"));
            var actualMenuItems = webElement.FindElements(By.TagName("option"));
            Assert.AreEqual(expectedMenuItemsCount, actualMenuItems.Count);
        }

        [TestMethod]
        public void Test_ClickAddButtonWithNoItem_AddsNoItemsToOrder()
        {
            const int expectedOrderRowCount = 0;
            _webDriver.Navigate().GoToUrl(RestaurantSite);
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
            _webDriver.Navigate().GoToUrl(RestaurantSite);
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
            _webDriver.Navigate().GoToUrl(RestaurantSite);
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
            _webDriver.Navigate().GoToUrl(RestaurantSite);
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
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            WaitForAjax();
            webElement = _webDriver.FindElement(By.Id("select_quantity"));
            var actualQuantity = webElement.Text;
            Assert.AreEqual(expectedQuantityValueLength, actualQuantity.Length);
        }

        [TestMethod]
        public void Test_AddItemToOrder_ClearsSelectedMenuItem()
        {
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            WaitForAjax();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[1]"));
            Assert.IsTrue(webElement.Selected);
        }

        [TestMethod]
        public void Test_ClickOrderButtonWithOneItem_DisplaysConfirmation()
        {
            const string expectedMessageTitle = "Confirmation";
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            WaitForAjax();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]/p"));
            var actualMessageTitle = webElement.Text;
            Assert.AreEqual(expectedMessageTitle, actualMessageTitle);
        }

        [TestMethod]
        public void Test_ClickOrderButtonWithOneItem_DisplaysExpectedMessage()
        {
            const string expectedMessage = "Message: Thank you for your order!";
            _webDriver.Navigate().GoToUrl(RestaurantSite);
            var webElement = _webDriver.FindElement(By.Id("select_quantity"));
            webElement.SendKeys("1");
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"select_item\"]/option[2]"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("add_btn"));
            webElement.Click();
            webElement = _webDriver.FindElement(By.Id("order_btn"));
            webElement.Click();
            WaitForAjax();
            webElement = _webDriver.FindElement(By.XPath("//*[@id=\"orderResponse\"]"));
            var actualMessage = webElement.Text;
            Assert.IsTrue(actualMessage.Contains(expectedMessage));
        }

        /// <summary>
        /// Only used to debug tests
        /// </summary>
        /// <param name="msToPause"></param>
        private static void PauseBrowser(int msToPause = 5000)
        {
            Thread.Sleep(msToPause);
        }

        /// <summary>
        /// Reference: https://stackoverflow.com/a/7203819/580268
        /// </summary>
        public void WaitForAjax()
        {
            while (true) // Handle timeout somewhere
            {
                var javaScriptExecutor = _webDriver as IJavaScriptExecutor;
                var ajaxIsComplete = javaScriptExecutor != null && (bool)javaScriptExecutor.ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
                Thread.Sleep(100);
            }
        }

        #region IDisposable Support

        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
                _webDriver.Dispose();

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposedValue = true;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SeleniumTests() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
