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
        protected const string adminUsername = "TestAdmin1";
        protected const string memberUsername = "TestMember1";
        protected const string employeeUsername = "TestEmployee1";
        protected const string password = "aA!123";


        public CVGSTestContainer()
        {
            homeURL = "https://localhost:44321/";
            profileUrl = "Identity/Account/Manage";
            loginUrl = "Identity/Account/Login";
            registerUrl = "Identity/Account/Register";
        }

        [SetUp]
        public virtual void Setup()
        {
            driver = new ChromeDriver();
            Login(adminUsername, password);
        }

        [TearDown]
        public virtual void TearDown()
        {
            driver.Close();
        }

        public virtual void LoginAsMember()
        {
            Logout();
            Login(user: memberUsername);
        }

        public virtual void LoginAsEmployee()
        {
            Logout();
            Login(user: employeeUsername);
        }

        public void Login(string user = adminUsername, string pass = password)
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
