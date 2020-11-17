using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    public class PersonalInformationTests : CVGSTestContainer
    {
        private string personalInformationURL;

        public PersonalInformationTests()
        {
            personalInformationURL = "Identity/Account/Manage/PersonalInformation";
        }

        [Test]
        public void PersonalInformation_NavigateToPage_URLIsPageURL()
        {
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
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
            IWebElement updateButton = driver.FindElement(By.Id("update-button"));
            updateButton.Click();
            //Refresh Page
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Check for changed first Name
            Assert.AreEqual(fName, driver.FindElement(By.Id(firstNameId)).GetAttribute("value"));
        }

        [TestCase("t")]
        [TestCase("tttttttttttttttttttttttttttttttttttttttttttttttttttttttt")]
        [Test]
        public void PersonalInformation_AttemptUpdateWithInvalidData_UpdateFailed(string a)
        {
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Input_FirstName
            string firstNameId = "Input_FirstName";
            IWebElement firstName = driver.FindElement(By.Id(firstNameId));
            firstName.Clear();
            firstName.SendKeys(a);
            //updateButton
            IWebElement updateButton = driver.FindElement(By.Id("update-button"));
            updateButton.Click();
            //Refresh Page
            driver.Navigate().GoToUrl(homeURL + personalInformationURL);
            //Check for changed first Name
            Assert.AreNotEqual(a, driver.FindElement(By.Id(firstNameId)).GetAttribute("value"));
        }
    }
}
