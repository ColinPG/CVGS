using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class CartTests : CVGSTestContainer
    {
        public const string cartURL = "Identity/Account/Cart";

        public CartTests()
        {
        }

        [Test]
        public void Cart_NavigateToCartAsMember_URLIsCart()
        {
            LoginAsMember();
            IWebElement cart = driver.FindElement(By.LinkText("Cart"));
            cart.Click();
            Assert.AreEqual(driver.Url, homeURL + cartURL);
        }

        [Test]
        public void Cart_NavigateToCartAsEmployee_URLIsNotCart()
        {
            LoginAsEmployee();
            IWebElement cart = null;
            try { cart = driver.FindElement(By.LinkText("Cart")); } catch { }
            Assert.IsNull(cart);
        }

        [Test]
        public void Cart_AddGameToCartGameIndex_GameIsAddedToCart()
        {
            LoginAsMember();
            ClearCart(driver);
            string gameTitleText = AddFirstGameToCart(driver);
            IWebElement message = driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual(gameTitleText + " added to cart.", message.Text);
        }

        public static string AddFirstGameToCart(IWebDriver dri)
        {
            IWebElement game = dri.FindElement(By.LinkText("Game"));
            game.Click();
            IWebElement gameTitle = dri.FindElement(By.Id("gameName"));
            string gameTitleText = gameTitle.Text;
            IWebElement addToCartLink = dri.FindElement(By.Id("addToCart"));
            addToCartLink.Click();
            return gameTitleText;
        }

        public static string AddFirstGameWithPriceToCart(IWebDriver dri, double setPrice)
        {
            IWebElement game = dri.FindElement(By.LinkText("Game"));
            game.Click();
            int gameNumber = 0;
            bool notFoundPricedGame = true;
            while(notFoundPricedGame)
            {
                IReadOnlyCollection<IWebElement> detailsList = dri.FindElements(By.LinkText("Details"));
                int curr = 0;
                foreach(IWebElement e in detailsList)
                {
                    if (curr == gameNumber)
                    {
                        
                        e.Click();
                        IWebElement priceText = dri.FindElement(By.Id("price"));
                        double pagePrice = double.Parse(priceText.Text.Trim('$'));
                        if (pagePrice == setPrice)
                            notFoundPricedGame = false;
                        else
                        {
                            gameNumber++;
                            IWebElement back = dri.FindElement(By.LinkText("Back to List"));
                            back.Click();
                        }
                        break;
                    }
                    curr++;
                }
            }
            IWebElement addToCartLink = dri.FindElement(By.Id("addToCart"));
            addToCartLink.Click();

            game = dri.FindElement(By.LinkText("Game"));
            game.Click();
            IReadOnlyCollection<IWebElement> gameTitles = dri.FindElements(By.Id("gameName"));
            string gameTitleText = "";
            int titleNum = 0;
            foreach(IWebElement e in gameTitles)
            {
                if (titleNum == gameNumber)
                    gameTitleText = e.Text;
                titleNum++;
            }
            return gameTitleText;
        }

        public static void ClearCart(IWebDriver dri)
        {
            IWebElement cart = dri.FindElement(By.LinkText("Cart"));
            cart.Click();
            bool noMoreGames = true;
            while (noMoreGames)
            {
                IReadOnlyCollection<IWebElement> elements = dri.FindElements(By.Id("remove"));
                if (elements.Count == 0)
                    noMoreGames = false;
                foreach (IWebElement e in elements)
                {
                    e.Click();
                    break;
                }
            }
        }

        public static void SetFirstGameFormat(IWebDriver dri, bool isDigital)
        {
            IWebElement cart = dri.FindElement(By.LinkText("Cart"));
            cart.Click();
            SelectElement formatDropDown = new SelectElement(dri.FindElement(By.Name("Input.cartItems[0].GameFormatCode")));
            if(isDigital)
                formatDropDown.SelectByValue("D");
            else
                formatDropDown.SelectByValue("P");
            IWebElement save = dri.FindElement(By.Id("SaveChanges"));
            save.Click();
        }

        [Test]
        public void Cart_AddGameToCartGameDetails_GameIsAddedToCart()
        {
            LoginAsMember();
            ClearCart(driver);
            IWebElement game = driver.FindElement(By.LinkText("Game"));
            game.Click();
            IWebElement gameTitle = driver.FindElement(By.Id("gameName"));
            string gameTitleText = gameTitle.Text;
            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement addToCartLink = driver.FindElement(By.Id("addToCart"));
            addToCartLink.Click();
            IWebElement message = driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual(gameTitleText + " added to cart.", message.Text);
        }

        [TestCase("D")] //Digital
        [TestCase("P")] //Physical
        [Test]
        public void Cart_ChangeCartItemGameFormat_CartItemFormatChanged(string letter)
        {
            LoginAsMember();
            ClearCart(driver);
            AddFirstGameToCart(driver);
            //First game dropdown name will be Input.cartItems[0].GameFormatCode
            SelectElement formatDropDown = new SelectElement(driver.FindElement(By.Name("Input.cartItems[0].GameFormatCode")));
            formatDropDown.SelectByValue(letter);
            //Save Changes button
            IWebElement save = driver.FindElement(By.Id("SaveChanges"));
            save.Click();
            IWebElement code = driver.FindElement(By.Name("Input.cartItems[0].GameFormatCode"));
            Assert.AreEqual(code.GetAttribute("value"), letter);
        }


        [TestCase("10")]
        [TestCase("50000")]
        [TestCase("5")]
        [Test]
        public void Cart_ChangeCartItemQuantity_QuantityChanged(string quantityValue)
        {
            LoginAsMember();
            ClearCart(driver);
            AddFirstGameToCart(driver);
            //First textbox will be Input.cartItems[0].Quantity
            IWebElement quantity = driver.FindElement(By.Name("Input.cartItems[0].Quantity"));
            quantity.Clear();
            quantity.SendKeys(quantityValue);
            //Save Changes button
            IWebElement save = driver.FindElement(By.Id("SaveChanges"));
            save.Click();
            quantity = driver.FindElement(By.Name("Input.cartItems[0].Quantity"));
            Assert.AreEqual(quantity.GetAttribute("value"), quantityValue);
        }

        [TestCase("test")]
        [TestCase("-50")]
        [TestCase("0")]
        [TestCase("2.5")]
        [Test]
        public void Cart_ChangeCartItemInvalidQuantity_QuantityNotChanged(string quantityValue)
        {
            LoginAsMember();
            ClearCart(driver);
            AddFirstGameToCart(driver);
            //First textbox will be Input.cartItems[0].Quantity
            IWebElement quantity = driver.FindElement(By.Name("Input.cartItems[0].Quantity"));
            string initialQuan = quantity.GetAttribute("value"); 
            quantity.Clear();
            quantity.SendKeys(quantityValue);
            //Save Changes button
            IWebElement save = driver.FindElement(By.Id("SaveChanges"));
            save.Click();
            IWebElement cart = driver.FindElement(By.LinkText("Cart"));
            cart.Click();
            quantity = driver.FindElement(By.Name("Input.cartItems[0].Quantity"));
            Assert.AreEqual(quantity.GetAttribute("value"), initialQuan);
        }

        [Test]
        public void Cart_RemoveCartItem_EmptyCart()
        {
            LoginAsMember();
            ClearCart(driver);
            AddFirstGameToCart(driver);

            IWebElement removeLink = driver.FindElement(By.Id("remove"));
            removeLink.Click();
            removeLink = null;
            try { removeLink = driver.FindElement(By.LinkText("remove")); } catch { }
            Assert.IsNull(removeLink);
            IWebElement message = driver.FindElement(By.Id("statusMessage"));
            Assert.AreEqual("Item removed from cart.", message.Text);
        }
    }
}
