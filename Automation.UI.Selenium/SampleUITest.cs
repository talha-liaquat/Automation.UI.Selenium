using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Automation.UI.Selenium
{
    [TestClass]
    public class SampleUITest
    {
        private ChromeDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestGoogleSearch_MSFT_ValidNASDAQCode()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElementByName("q").SendKeys("MSFT");
            driver.FindElementByName("btnK").Submit();

            Assert.IsTrue(driver.FindElementById("knowledge-finance-wholepage__entity-summary").Text.Contains("NASDAQ: MSFT"));
        }

        [TestMethod]
        public void TestGoogleSearch_APPL_ValidNASDAQCode()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");

            driver.FindElementByName("q").SendKeys("appl nasdaq");
            driver.FindElementByName("btnK").Submit();

            Assert.IsTrue(driver.FindElementById("knowledge-finance-wholepage__entity-summary").Text.Contains("NASDAQ: AAPL"));
        }

        [TestCleanupAttribute]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
