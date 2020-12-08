using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class OrderTests : CVGSTestContainer
    {
        private readonly string orderURL;
        private readonly string orderDetailsURL;

        public OrderTests()
        {
            orderURL = "Employee/Orders";
            orderDetailsURL = "Employee/OrderDetails";
        }


        [Test]
        public void Order_NavigateToOrdersAsMember_URLIsHome()
        {
            LoginAsMember();
            IWebElement orderLink = null;
            try { orderLink = driver.FindElement(By.LinkText("Orders")); } catch { }
            Assert.IsNull(orderLink);
        }

        [Test]
        public void Order_NavigateToOrdersAsEmployee_URLIsOrders()
        {
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            Assert.AreEqual(driver.Url, homeURL + orderURL);
        }

        [Test]
        public void Order_NavigateToOrderDetailsAsEmployee_URLIsOrders()
        {
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            IWebElement detailsLink = driver.FindElement(By.LinkText("Details"));
            detailsLink.Click();
            Assert.True(driver.Url.Contains(orderDetailsURL));
        }

        [Test]
        public void Order_PurchaseOnePricedDigital_OrderExistsAsProccessed()
        {
            LoginAsMember();
            string gameName = CheckoutTests.SetupValidCartOneGame(this, driver, 20, true);
            CheckoutTests.FillCheckoutForm(driver);
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            Assert.AreEqual(driver.Url, homeURL + orderURL);
            IWebElement status = driver.FindElement(By.Id("orderStatus"));
            Assert.AreEqual(status.Text, "Processed");

            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement gameTitle = driver.FindElement(By.Id("GameTitle"));
            Assert.AreEqual(gameTitle.Text, gameName);
        }

        [Test]
        public void Order_PurchaseOneFreeDigital_OrderExistsAsProccessed()
        {
            LoginAsMember();
            string gameName = CheckoutTests.SetupValidCartOneGame(this, driver, 0, true);
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            Assert.AreEqual(driver.Url, homeURL + orderURL);
            IWebElement status = driver.FindElement(By.Id("orderStatus"));
            Assert.AreEqual(status.Text, "Processed");

            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement gameTitle = driver.FindElement(By.Id("GameTitle"));
            Assert.AreEqual(gameTitle.Text, gameName);
        }

        [Test]
        public void Order_PurchaseOnePricedPhysical_OrderExistsAsPending()
        {
            LoginAsMember();
            string gameName = CheckoutTests.SetupValidCartOneGame(this, driver, 20, false);
            CheckoutTests.FillCheckoutForm(driver);
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            Assert.AreEqual(driver.Url, homeURL + orderURL);
            IWebElement status = driver.FindElement(By.Id("orderStatus"));
            Assert.AreEqual(status.Text, "Pending");

            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement gameTitle = driver.FindElement(By.Id("GameTitle"));
            Assert.AreEqual(gameTitle.Text, gameName);
        }


        [Test]
        public void Order_ChangeOrderPendingToProcessed_OrderChangedToProcessed()
        {
            LoginAsMember();
            string gameName = CheckoutTests.SetupValidCartOneGame(this, driver, 20, false);
            CheckoutTests.FillCheckoutForm(driver);
            LoginAsEmployee();
            IWebElement orderLink = driver.FindElement(By.LinkText("Orders"));
            orderLink.Click();
            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement gameTitle = driver.FindElement(By.Id("GameTitle"));
            Assert.AreEqual(gameTitle.Text, gameName);
            IWebElement markAsProcessed = driver.FindElement(By.Id("mark"));
            markAsProcessed.Click();
            IWebElement message = driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual(message.Text, "Order marked as Processed!");
            IWebElement back = driver.FindElement(By.LinkText("Back to Orders List"));
            back.Click();
            IWebElement status = driver.FindElement(By.Id("orderStatus"));
            Assert.AreEqual(status.Text, "Processed");
        }
    }
}
