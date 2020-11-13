using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    public class CVGSTestContainer
    {
        protected IWebDriver driver;

        protected string homeURL;
        protected string profileUrl;
        protected string loginUrl;
        protected string registerUrl;
        protected string employeeUsername;
        protected string password;

        //Game tests
        protected string gameUrl;
        protected string gameCreateUrl;
        protected string gameEditUrl;
        protected string gameDetailsUrl;
        protected string gameDeleteUrl;

        public CVGSTestContainer()
        {
            homeURL = "https://localhost:44321/";
            profileUrl = "Identity/Account/Manage";
            loginUrl = "Identity/Account/Login";
            registerUrl = "Identity/Account/Register";

            employeeUsername = "Employee@test.com";
            password = "aA!123";


            gameUrl = "Game";
            gameCreateUrl = "Game/Create/";
            gameEditUrl = "Game/Edit/";
            gameDetailsUrl = "Game/Details/";
            gameDeleteUrl = "Game/Delete/";
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            Login(employeeUsername, password);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

        public void Login(string user, string pass)
        {
            driver.Navigate().GoToUrl(homeURL + loginUrl);
            //Accept cookies, if not accepted already.
            try
            {
                IWebElement cookiesLink = driver.FindElement(By.ClassName("accept-policy"));
                cookiesLink.Click();
            }
            catch { }

            //Input_UserName
            IWebElement usernameTextbox = driver.FindElement(By.Id("Input_UserName"));
            usernameTextbox.SendKeys(user);
            //Input_Password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Input_Password"));
            passwordTextbox.SendKeys(pass);
            usernameTextbox.Submit();
        }

        public void Logout()
        {
            IWebElement logoutLink = driver.FindElement(By.Id("logout"));
            logoutLink.Click();
        }
    }
}
