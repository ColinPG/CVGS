using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class WishListTests : CVGSTestContainer
    {
        private readonly string wishListURL;

        public WishListTests()
        {
            wishListURL = "Identity/Account/Manage/WishList";
        }

        [Test]
        public void WishList_NavigateToWishListAsMember_URLIsWishList()
        {
            NavigateToMemberWishList();
            Assert.AreEqual(driver.Url, homeURL + wishListURL);
        }

        private void NavigateToMemberWishList()
        {
            Logout();
            Login(user: memberUsername);
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            IWebElement wList = driver.FindElement(By.LinkText("Wishlist"));
            wList.Click();
        }

        [Test]
        public void WishList_NavigateToWishListAsEmployee_WishListLinkNotFound()
        {
            Logout();
            Login(user: employeeUsername);
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            IWebElement wList = null;
            try { driver.FindElement(By.LinkText("Wishlist")); } catch { }
            Assert.IsNull(wList);
            Assert.AreEqual(driver.Url, homeURL + profileUrl);
        }

        [Test]
        public void WishList_AddGameToWishList_GameAddedToWishList()
        {
            NavigateToMemberWishList();
            ClearWishList();
            AddFirstGameOnPageToWishList();
            IWebElement statusMessage = driver.FindElement(By.Id("statusMessage"));
            Assert.True(statusMessage.Text.Contains("added to wishlist."));
        }

        [Test]
        public void WishList_AddGameToWishListFromDetails_GameAddedToWishList()
        {
            NavigateToMemberWishList();
            ClearWishList();
            IWebElement game = driver.FindElement(By.LinkText("Game"));
            game.Click();
            IWebElement details = driver.FindElement(By.LinkText("Details"));
            details.Click();
            IWebElement addToWishlist = driver.FindElement(By.Id("addToWishlist"));
            addToWishlist.Click();
            IWebElement statusMessage = driver.FindElement(By.Id("statusMessage"));
            Assert.True(statusMessage.Text.Contains("added to wishlist."));
        }

        private void AddFirstGameOnPageToWishList()
        {
            IWebElement game = driver.FindElement(By.LinkText("Game"));
            game.Click();
            IWebElement addToWishlist = driver.FindElement(By.Id("addToWishlist"));
            addToWishlist.Click();
        }

        private void ClearWishList()
        {
            bool noMoreGames = true;
            while(noMoreGames)
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("remove"));
                if (elements.Count == 0)
                    noMoreGames = false;
                foreach (IWebElement e in elements)
                {
                    e.Click();
                    break;
                }
            }
        }

        [Test]
        public void WishList_AttemptAddExistingGameToWishList_NoNewWishListItemAdded()
        {
            NavigateToMemberWishList();
            ClearWishList();
            AddFirstGameOnPageToWishList();
            AddFirstGameOnPageToWishList(); //Running a second time will attempt to add the same game twice
            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));
            Assert.True(tempMessage.Text.Contains("is already on wishlist."));
        }

        [Test]
        public void WishList_RemoveGameFromWishList_NoNewWishListItemAdded()
        {
            NavigateToMemberWishList();
            ClearWishList();
            AddFirstGameOnPageToWishList();
            IWebElement removeLink = driver.FindElement(By.Id("remove"));
            removeLink.Click();
            IWebElement statusMessage = driver.FindElement(By.Id("statusMessage"));
            Assert.True(statusMessage.Text.Contains("Item removed from cart."));
        }
    }
}
