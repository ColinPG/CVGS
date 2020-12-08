using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class CheckoutTests : CVGSTestContainer
    {
        private readonly string checkoutURL;

        public CheckoutTests()
        {
            checkoutURL = "Identity/Account/Checkout";
        }


        [Test]
        public void Checkout_NavigateToCheckoutWithNoItems_URLIsCart()
        {
            AddressTests.RemoveAllAddresses(driver);
            AddressTests.AddDefaultAddresses(driver);
            CartTests.ClearCart(driver);
            driver.Navigate().GoToUrl(homeURL + checkoutURL);
            Assert.AreEqual(driver.Url, homeURL + CartTests.cartURL);
            IWebElement message = driver.FindElement(By.Id("TempMessage"));
            Assert.AreEqual(message.Text, "Unable to checkout with no items in cart.");
        }

        [Test]
        public void Checkout_NavigateToCheckoutWithNoAddresses_URLIsAddresses()
        {
            AddressTests.RemoveAllAddresses(driver);
            CartTests.ClearCart(driver);
            CartTests.AddFirstGameWithPriceToCart(driver, 20);
            CartTests.SetFirstGameFormat(driver, false);
            IWebElement cart = driver.FindElement(By.LinkText("Cart"));
            cart.Click();
            IWebElement checkout = driver.FindElement(By.Id("Checkout"));
            checkout.Click();
            Assert.AreEqual(driver.Url, homeURL + AddressTests.addressesUrl);
        }

        [Test]
        public void Checkout_CheckoutOneFreeGame_OneFreeGameAddedToAccount()
        {
            SetupValidCartOneGame(this, driver, 0);
            Assert.AreEqual(driver.Url, homeURL);
            IWebElement success = driver.FindElement(By.Id("TempSuccess"));
            Assert.AreEqual(success.Text, "All games in cart were free! Added to account.");
        }

        [Test]
        public void Checkout_CheckoutOnePricedGame_OnePricedGameAddedToAccount()
        {
            SetupValidCartOneGame(this, driver, 20);
            FillCheckoutForm(driver, "1234567890123456", "123", (DateTime.Now.Year - 2000 + 1).ToString(), "12");
            Assert.AreEqual(driver.Url, homeURL);
            IWebElement success = driver.FindElement(By.Id("TempSuccess"));
            Assert.AreEqual(success.Text, "Order succesfully placed!");
        }

        public static void FillCheckoutForm(IWebDriver dri, string credit = "1234567890123456", string sec = "123", string yr = "55", string mon = "12")
        {
            //Input_creditCardNumber textbox
            IWebElement creditCard = dri.FindElement(By.Id("Input_creditCardNumber"));
            creditCard.Clear();
            creditCard.SendKeys(credit);
            //Input_securityCode textbox
            IWebElement secCode = dri.FindElement(By.Id("Input_securityCode"));
            secCode.Clear();
            secCode.SendKeys(sec);
            //Input_month textbox
            IWebElement month = dri.FindElement(By.Id("Input_month"));
            month.Clear();
            month.SendKeys(mon);
            //Input_year textbox
            IWebElement year = dri.FindElement(By.Id("Input_year"));
            year.Clear();
            year.SendKeys(yr);
            //Input_mailingSelected radio button
            IWebElement addMailing = dri.FindElement(By.Id("Input_mailingSelected"));
            addMailing.Click();
            //Input_shipppingSelected radio button
            IWebElement addrShipping = dri.FindElement(By.Id("Input_shipppingSelected"));
            addrShipping.Click();
            //submit button
            IWebElement submitButton = dri.FindElement(By.Id("submit"));
            submitButton.Click();
        }

        public static string SetupValidCartOneGame(CVGSTestContainer container, IWebDriver dri, double gamePrice, bool isDigitalGame = true)
        {
            container.LoginAsMember();
            AddressTests.RemoveAllAddresses(dri);
            AddressTests.AddDefaultAddresses(dri);
            CartTests.ClearCart(dri);
            string result = CartTests.AddFirstGameWithPriceToCart(dri, gamePrice);
            CartTests.SetFirstGameFormat(dri, isDigitalGame);
            IWebElement cart = dri.FindElement(By.LinkText("Cart"));
            cart.Click();
            IWebElement checkout = dri.FindElement(By.Id("Checkout"));
            checkout.Click();
            return result;
        }

        [TestCase("", "", "", "")]
        [TestCase("1234567890123456", "123", "", "")]
        [TestCase("1234567890123456", "123", "12", "")]
        [TestCase("1234567890123456", "123", "12", "19")]
        [TestCase("123456789012345", "123", "12", "55")]
        [TestCase("1234567890123456", "1234", "12", "55")]
        [TestCase("test", "test", "test", "test")]
        [Test]
        public void Checkout_CheckoutInvalidCreditInfo_FailAtCheckout(string credit, string sec, string month, string year)
        {
            SetupValidCartOneGame(this, driver, 20);
            FillCheckoutForm(driver, credit, sec, year, month);
            Assert.AreEqual(driver.Url, homeURL + checkoutURL);
        }

        [Test]
        public void Checkout_CheckoutOneGame_OneGameInLibrary()
        {
            string gameName = SetupValidCartOneGame(this, driver, 20);
            FillCheckoutForm(driver);
            Assert.AreEqual(driver.Url, homeURL);
            IWebElement success = driver.FindElement(By.Id("TempSuccess"));
            Assert.AreEqual(success.Text, "Order succesfully placed!");

            IWebElement library = driver.FindElement(By.LinkText("Library"));
            library.Click();
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("gameName"));
            bool foundGame = false;
            foreach (IWebElement e in elements)
            {
                if (e.Text == gameName)
                    foundGame = true;
            }
            Assert.True(foundGame);
        }
    }
}
