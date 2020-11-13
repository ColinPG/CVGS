using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class IdentityTests : CVGSTestContainer
    {
        private string userUsername;
        private string newUserPassword;
        private string userGamerTag;

        public IdentityTests()
        {
            userUsername = "test@test.com";
            newUserPassword = "Aa!123";
            userGamerTag = "SeleniumGamerTag";
        }

        [Test, Order(1)]
        public void IdentityLogin_Login_LoggedIn()
        {
            driver.Navigate().GoToUrl(homeURL);
            IWebElement logoutLink = driver.FindElement(By.Id("logout"));
            //If login succeeds, logoutlink will be present.
            Assert.IsNotNull(logoutLink);
        }

        [Test, Order(2)]
        public void IdentityProfile_NavigateToProfile_URLIsProfile()
        {
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            //If login failed, profile page is inaccessible by all non-users
            Assert.AreEqual(driver.Url, homeURL + profileUrl);
        }

        [Test, Order(3)]
        public void IdentityLogout_Logout_Loggedout()
        {
            Logout();
            driver.Navigate().GoToUrl(homeURL + profileUrl);
            Assert.AreNotEqual(driver.Url, homeURL + profileUrl);
        }


        [Test, Order(4)]
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

        [Test, Order(5)]
        public void IdentityChangePassword_ChangePassword_PasswordChanged()
        {
            Logout();
            Login(user: userUsername);
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

        [Test, Order(6)]
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

        [Test, Order(7)]
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
    }
}
