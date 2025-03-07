﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    public class ProfileTests : CVGSTestContainer
    {
        private string personalInformationURL;

        public ProfileTests()
        {
            personalInformationURL = "Identity/Account/Manage";
        }

        [Test]
        public void PersonalInformation_NavigateToPage_URLIsPageURL()
        {
            driver.Navigate().GoToUrl(homeURL);
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            Assert.AreEqual(driver.Url, homeURL + personalInformationURL);
        }

        [TestCase("Test Name")]
        [TestCase("First Name")]
        [TestCase("")]
        [Test]
        public void PersonalInformation_UpdateFirstName_FirstNameUpdated(string fName)
        {
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Input_FirstName
            string firstNameId = "Input_FirstName";
            IWebElement firstName = driver.FindElement(By.Id(firstNameId));
            firstName.Clear();
            firstName.SendKeys(fName);
            //updateButton
            IWebElement updateButton = driver.FindElement(By.Id("update-profile-button"));
            updateButton.Click();
            //Refresh Page
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Check for changed first Name
            Assert.AreEqual(fName, driver.FindElement(By.Id(firstNameId)).GetAttribute("value"));
        }

        [TestCase("tttttttttttttttttttttttttttttttttttttttttttttttttttttttt")]
        [Test]
        public void PersonalInformation_AttemptUpdateWithInvalidData_UpdateFailed(string fName)
        {
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Input_FirstName
            string firstNameId = "Input_FirstName";
            IWebElement firstName = driver.FindElement(By.Id(firstNameId));
            firstName.Clear();
            firstName.SendKeys(fName);
            //updateButton
            IWebElement updateButton = driver.FindElement(By.Id("update-profile-button"));
            updateButton.Click();
            //Refresh Page
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Check for changed first Name
            Assert.AreNotEqual(fName, driver.FindElement(By.Id(firstNameId)).GetAttribute("value"));
        }
    }
}
