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
            personalInformationURL = "/Identity/Account/Manage/PersonalInformation";
        }

        [Test, Order(1)]
        public void PersonalInformation_NavigateToIndex_URLIsIndex()
        {
            driver.Navigate().GoToUrl(homeURL);
            Assert.AreEqual(driver.Url, homeURL);
        }
    }
}
