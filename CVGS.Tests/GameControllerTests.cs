using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CVGS.Tests
{
    public class GameControllerTests : CVGSTestContainer
    {
        //Test Game guid
        private string guid;
        //Game Urls
        private string gameUrl;
        private string gameCreateUrl;
        private string gameEditUrl;
        private string gameDetailsUrl;
        private string gameDeleteUrl;
        
        //Game Test Data
        private string gameTitleData;
        private string gameEdittedTitleData;

        public GameControllerTests()
        {
            guid = "";

            gameUrl = "Game";
            gameCreateUrl = "Game/Create/";
            gameEditUrl = "Game/Edit/";
            gameDetailsUrl = "Game/Details/";
            gameDeleteUrl = "Game/Delete/";

            gameTitleData = "Selenium Test Game";
            gameEdittedTitleData = "Selenium Editted Test Game";
        }

        [Test, Order(1)]
        public void GameController_NavigateToCreate_URLIsCreate()
        {
            string createUrl = homeURL + gameCreateUrl;
            driver.Navigate().GoToUrl(createUrl);
            Assert.AreEqual(driver.Url, createUrl);
        }

        [TestCase("15", "1", "Selenium Test Description", "Selenium Test Detail")]
        [Test, Order(2)]
        public void GameController_CreateNewGame_GameIsCreated(string price, string player, string desc, string det)
        {
            string createUrl = homeURL + gameCreateUrl;
            driver.Navigate().GoToUrl(createUrl);

            //Form Data
            //EnglishName
            IWebElement title = driver.FindElement(By.Id("EnglishName"));
            title.SendKeys(gameTitleData);
            //Price
            IWebElement priceBox = driver.FindElement(By.Id("Price"));
            priceBox.SendKeys(price);
            //EnglishPlayerCount
            IWebElement players = driver.FindElement(By.Id("EnglishPlayerCount"));
            players.SendKeys(player);
            //EnglishDescription
            IWebElement description = driver.FindElement(By.Id("EnglishDescription"));
            description.SendKeys(desc);
            //EnglishDetail
            IWebElement detail = driver.FindElement(By.Id("EnglishDetail"));
            detail.SendKeys(det);

            //SubmitButton
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            string resultTitleData = ParseTitleFromTempData();

            Assert.AreEqual(driver.Url, homeURL + gameUrl);
            Assert.AreEqual(gameTitleData, resultTitleData);
        }

        [Test, Order(3)]
        public void GameController_NavigateToEdit_URLIsEdit()
        {
            string editUrl = homeURL + gameEditUrl + guid;
            driver.Navigate().GoToUrl(editUrl);
            Assert.AreEqual(driver.Url, editUrl);
        }
        
        [Test, Order(4)]
        public void GameController_EditTestGame_GameIsEditted()
        {
            string editUrl = homeURL + gameEditUrl + guid;
            driver.Navigate().GoToUrl(editUrl);
            //Title Textbox
            IWebElement title = driver.FindElement(By.Id("EnglishName"));
            title.Clear();
            title.SendKeys(gameEdittedTitleData);
            //SaveButton
            IWebElement saveButton = driver.FindElement(By.Id("save"));
            saveButton.Click();

            string resultTitleData = ParseTitleFromTempData();

            Assert.AreEqual(driver.Url, homeURL + gameUrl);
            Assert.AreEqual(gameEdittedTitleData, resultTitleData);
        }

        [Test, Order(5)]
        public void GameController_NavigateToDetails_URLIsDetails()
        {
            string detailUrl = homeURL + gameDetailsUrl + guid;
            driver.Navigate().GoToUrl(detailUrl);
            Assert.AreEqual(driver.Url, detailUrl);
        }

        [Test, Order(6)]
        public void GameController_NavigateToDelete_URLIsDelete()
        {
            string deleteUrl = homeURL + gameDeleteUrl + guid;
            driver.Navigate().GoToUrl(deleteUrl);
            Assert.AreEqual(driver.Url, deleteUrl);
        }

        [Test, Order(7)]
        public void GameController_DeleteTestGame_TestGameIsDeleted()
        {
            string deleteUrl = homeURL + gameDeleteUrl + guid;
            driver.Navigate().GoToUrl(deleteUrl);
            IWebElement deleteButton = driver.FindElement(By.Id("delete"));
            deleteButton.Click();
            string resultTitleData = ParseTitleFromTempData();

            Assert.AreEqual(driver.Url, homeURL + gameUrl);
            Assert.AreEqual(gameEdittedTitleData, resultTitleData);
        }


        private string ParseTitleFromTempData()
        {
            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));
            string tempmsg = tempMessage.Text;
            string[] messages = tempmsg.Split(new string[] 
                { "Editted Game: ", "Game: ", "New Game: "," created", " deleted", " with ", "id:" },
                StringSplitOptions.RemoveEmptyEntries);
            //Save GUID
            guid = messages[messages.Length - 1];
            string resultTitleData = messages[0];
            return resultTitleData;
        }
    }
}