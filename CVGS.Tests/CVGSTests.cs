using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace CVGS.Tests
{
    public class CVGSTests : CVGSTestContainer
    {

        private string guid;
        private string gameTitleData;
        private string gameEdittedTitleData;


        private string userUsername;
        private string newUserPassword;
        private string userGamerTag;
        private string gamePlayerData;
        private string gameDescriptionData;
        private string gameDetailData;

        public CVGSTests()
        {
            guid = "";
            gameTitleData = "Selenium Test Game";
            gamePlayerData = "1";
            gameDescriptionData = "Selenium Test Description";
            gameDetailData = "Selenium Test Detail"; 
            gameEdittedTitleData = "Selenium Editted Test Game";

            userUsername = "test@test.com"; 
            newUserPassword = "Aa!123";
            userGamerTag = "SeleniumGamerTag";
        }

        [Test, Order(1)]
        public void HomeController_NavigateToIndex_URLIsIndex()
        {
            driver.Navigate().GoToUrl(homeURL);
            Assert.AreEqual(driver.Url, homeURL);
        }

        [Test, Order(2)]
        public void IdentityLogin_Login_LoggedIn()
        {
            driver.Navigate().GoToUrl(homeURL);
            IWebElement logoutLink = driver.FindElement(By.Id("logout"));
            //If login succeeds, logoutlink will be present.
            Assert.IsNotNull(logoutLink);
        }

        [Test, Order(3)]
        public void IdentityProfile_NavigateToProfile_URLIsProfile()
        {
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            //If login failed, profile page is inaccessible by all non-users
            Assert.AreEqual(driver.Url, homeURL + profileUrl);
        }

        [Test, Order(4)]
        public void IdentityLogout_Logout_Loggedout()
        {
            Logout();
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            Assert.AreNotEqual(driver.Url, homeURL + profileUrl);
        }

        [Test, Order(5)]
        public void GameController_NavigateToCreate_URLIsCreate()
        {
            string createUrl = homeURL + gameCreateUrl;
            driver.Navigate().GoToUrl(createUrl);
            Assert.AreEqual(driver.Url, createUrl);
        }


        [Test, Order(6)]
        public void GameController_CreateNewGame_GameIsCreated()
        {
            string createUrl = homeURL + gameCreateUrl;
            driver.Navigate().GoToUrl(createUrl);

            //Form Data
            //EnglishName
            IWebElement title = driver.FindElement(By.Id("EnglishName"));
            title.SendKeys(gameTitleData);
            //EnglishPlayerCount
            IWebElement players = driver.FindElement(By.Id("EnglishPlayerCount"));
            players.SendKeys(gamePlayerData);
            //EnglishDescription
            IWebElement description = driver.FindElement(By.Id("EnglishDescription"));
            description.SendKeys(gameDescriptionData);
            //EnglishDetail
            IWebElement detail = driver.FindElement(By.Id("EnglishDetail"));
            detail.SendKeys(gameDetailData);

            //SubmitButton
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            string resultTitleData = ParseTitleFromTempData();

            Assert.AreEqual(driver.Url, homeURL + gameUrl);
            Assert.AreEqual(gameTitleData, resultTitleData);
        }

        [Test, Order(7)]
        public void GameController_NavigateToEdit_URLIsEdit()
        {
            string editUrl = homeURL + gameEditUrl + guid;
            driver.Navigate().GoToUrl(editUrl);
            Assert.AreEqual(driver.Url, editUrl);
        }
        
        [Test, Order(8)]
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

        [Test, Order(9)]
        public void GameController_NavigateToDetails_URLIsDetails()
        {
            string detailUrl = homeURL + gameDetailsUrl + guid;
            driver.Navigate().GoToUrl(detailUrl);
            Assert.AreEqual(driver.Url, detailUrl);
        }

        [Test, Order(10)]
        public void GameController_NavigateToDelete_URLIsDelete()
        {
            string deleteUrl = homeURL + gameDeleteUrl + guid;
            driver.Navigate().GoToUrl(deleteUrl);
            Assert.AreEqual(driver.Url, deleteUrl);
        }

        [Test, Order(11)]
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

        [Test, Order(12)]
        public void IdentityRegister_CreateNewTestAccount_TestAccountCreated()
        {
            Logout();
            driver.Navigate().GoToUrl(homeURL + registerUrl);
            //Input_UserName
            IWebElement userName = driver.FindElement(By.Id("Input_UserName"));
            userName.Clear();
            userName.SendKeys(userUsername);
            //Input_Email
            IWebElement email = driver.FindElement(By.Id("Input_Email"));
            email.SendKeys(userUsername);
            //Input_Password
            IWebElement passwordTextBox = driver.FindElement(By.Id("Input_Password"));
            passwordTextBox.SendKeys(password);
            //Input_ConfirmPassword
            IWebElement confirmPassword = driver.FindElement(By.Id("Input_ConfirmPassword"));
            confirmPassword.SendKeys(password);
            //Input_GamerTag
            IWebElement gamerTag = driver.FindElement(By.Id("Input_GamerTag"));
            gamerTag.SendKeys(userGamerTag);
            //registerButton
            IWebElement registerButton = driver.FindElement(By.Id("register"));
            registerButton.Click();
            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));

            Assert.AreEqual($"Account: {userUsername} created.", tempMessage.Text);
            
        }

        [Test, Order(13)]
        public void IdentityChangePassword_ChangePassword_PasswordChanged()
        {
            Logout();
            Login(userUsername, password);
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            driver.FindElement(By.Id("change-password")).Click();
            //Input_OldPassword
            IWebElement oldPass = driver.FindElement(By.Id("Input_OldPassword"));
            oldPass.Clear();
            oldPass.SendKeys(password);
            //Input_NewPassword
            IWebElement newPass = driver.FindElement(By.Id("Input_NewPassword"));
            newPass.SendKeys(newUserPassword);
            //Input_ConfirmPassword
            IWebElement confirmPass = driver.FindElement(By.Id("Input_ConfirmPassword"));
            confirmPass.SendKeys(newUserPassword);
            //updateButton
            IWebElement updateButton = driver.FindElement(By.Id("update"));
            updateButton.Click();

            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));
            Assert.AreEqual("Password changed successfully.", tempMessage.Text);
        }

        [Test, Order(14)]
        public void IdentityIndex_ChangeProfile_ProfileUpdated()
        {
            Logout();
            Login(userUsername, newUserPassword);
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            //Input_GamerTag
            IWebElement gamerTag = driver.FindElement(By.Id("Input_GamerTag"));
            string newTag = userGamerTag.Substring(0, userGamerTag.Length - 2);
            gamerTag.Clear();
            gamerTag.SendKeys(newTag);
            //updateButton
            IWebElement updateButton = driver.FindElement(By.Id("update-profile-button"));
            updateButton.Click();

            //Check for update message
            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));
            Assert.AreEqual("Profile updated.", tempMessage.Text);
            //Check for changed gamerTag
            Assert.AreEqual(newTag, driver.FindElement(By.Id("Input_GamerTag")).GetAttribute("value"));
        }

        [Test, Order(15)]
        public void IdentityPersonalData_DeleteTestAccount_TestAccountDeleted()
        {
            Logout();
            Login(userUsername, newUserPassword);
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            driver.FindElement(By.Id("personal-data")).Click();
            driver.FindElement(By.Id("delete")).Click();
            IWebElement passwordTextBox = driver.FindElement(By.Id("Input_Password"));
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(newUserPassword);
            IWebElement deleteButton = driver.FindElement(By.Id("delete"));
            deleteButton.Click();

            IWebElement tempMessage = driver.FindElement(By.Id("TempMessage"));
            Assert.AreEqual($"User deleted {userUsername} deleted themselves.", tempMessage.Text);
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