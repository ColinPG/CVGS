using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    public class PreferenceTests : CVGSTestContainer
    {
        private string preferenceUrl;
        private string changePreferenceUrl;
        private const string platformTestData = "Sony PlayStation 1";
        private const string categoryTestData = "Action";
        private const string subcategoryTestData = "Adventure";

        private const string platformDropDownId = "listPlatform";
        private const string categoryDropDownId = "listCategory";
        private const string subCategoryDropDownId = "listSubcategory";

        private const string addPlatformButtonId = "addPlatform";
        private const string addCategoryButtonId = "addCategory";
        private const string addSubCategoryButtonId = "addSubcategory";

        public PreferenceTests()
        {
            preferenceUrl = "Identity/Account/Manage/Preferences";
            changePreferenceUrl = "Identity/Account/Manage/ChangePreferences";
        }

        [Test]
        public void Preferences_NavigateToPreferences_URLIsPreferences()
        {
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            IWebElement preferences = driver.FindElement(By.LinkText("Preferences"));
            preferences.Click();
            Assert.AreEqual(driver.Url, homeURL + preferenceUrl);
        }

        [Test]
        public void Preferences_NavigateToChangePreferences_URLIsChangePreferences()
        {
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            IWebElement preferences = driver.FindElement(By.LinkText("Preferences"));
            preferences.Click();
            IWebElement changePreferences = driver.FindElement(By.LinkText("Change Preferences"));
            changePreferences.Click();
            Assert.AreEqual(driver.Url, homeURL + changePreferenceUrl);
        }

        [Test, Order(1)]
        public void Preferences_RemovePreferenceWhenNoneExist_NoPreferencesListed()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("btn-link"));
            //default should have no preferences to start, therefore no remove links are found.
            foreach(IWebElement e in elements)
            {
                Assert.AreNotEqual(e.GetAttribute("value"), "Remove");
            }
        }

        [Test, Order(2)]
        public void Preferences_AddPlatformPref_PlatformIsAdded()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            SelectElement preferenceDropDown = new SelectElement(driver.FindElement(By.Id(platformDropDownId)));
            preferenceDropDown.SelectByValue(platformTestData);
            IWebElement addButton = driver.FindElement(By.Id(addPlatformButtonId));
            addButton.Click();
            IWebElement removeButton = driver.FindElement(By.Id(platformTestData));
            //If there exists a remove button for the value just added, then it was added successfully.
            Assert.IsNotNull(removeButton);
        }

        [Test, Order(3)]
        public void Preferences_AddExistingPreference_FailToFindPreference()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement removeButton = driver.FindElement(By.Id(platformTestData));
            // Make sure that element is already selected
            Assert.IsNotNull(removeButton);
            SelectElement preferenceDropDown = new SelectElement(driver.FindElement(By.Id(platformDropDownId)));
            try { 
                preferenceDropDown.SelectByValue(platformTestData); //Should throw exception here
                Assert.Fail("Found already existing platform preference in dropdown.");
            } 
            catch 
            {
                Assert.Pass("No preference Found!");
            }
        }

        [Test, Order(4)]
        public void Preferences_AddCategoryPref_CategoryIsAdded()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            SelectElement preferenceDropDown = new SelectElement(driver.FindElement(By.Id(categoryDropDownId)));
            preferenceDropDown.SelectByValue(categoryTestData);
            IWebElement addButton = driver.FindElement(By.Id(addCategoryButtonId));
            addButton.Click();
            IWebElement removeButton = driver.FindElement(By.Id(categoryTestData));
            //If there exists a remove button for the value just added, then it was added successfully.
            Assert.IsNotNull(removeButton);
        }

        [Test, Order(5)]
        public void Preferences_AddSubcategoryPref_SubCategoryIsAdded()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            SelectElement preferenceDropDown = new SelectElement(driver.FindElement(By.Id(subCategoryDropDownId)));
            preferenceDropDown.SelectByValue(subcategoryTestData);
            IWebElement addButton = driver.FindElement(By.Id(addSubCategoryButtonId));
            addButton.Click();
            IWebElement removeButton = driver.FindElement(By.Id(subcategoryTestData));
            //If there exists a remove button for the value just added, then it was added successfully.
            Assert.IsNotNull(removeButton);
        }

        [Test, Order(6)]
        public void Preferences_RemovePlatformPref_PlatformIsRemoved()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement removeButton = driver.FindElement(By.Id(platformTestData));
            removeButton.Click();
            removeButton = null;
            try { removeButton = driver.FindElement(By.Id(platformTestData)); } catch { }
            //If there exists a remove button for the value just removed, then it was NOT removed successfully.
            Assert.IsNull(removeButton);
        }

        [Test, Order(7)]
        public void Preferences_RemoveCategoryPref_CategoryIsRemoved()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement removeButton = driver.FindElement(By.Id(categoryTestData));
            removeButton.Click();
            removeButton = null;
            try { removeButton = driver.FindElement(By.Id(categoryTestData)); } catch { }
            //If there exists a remove button for the value just removed, then it was NOT removed successfully.
            Assert.IsNull(removeButton);
        }

        [Test, Order(8)]
        public void Preferences_RemoveSubcategoryPref_SubCategoryIsRemoved()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement removeButton = driver.FindElement(By.Id(subcategoryTestData));
            removeButton.Click();
            removeButton = null;
            try { removeButton = driver.FindElement(By.Id(subcategoryTestData)); } catch { }
            //If there exists a remove button for the value just removed, then it was NOT removed successfully.
            Assert.IsNull(removeButton);
        }

        [Test, Order(9)]
        public void Preferences_RemoveNonSelectedPreference_PreferenceNotFound()
        {
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement removeButton = null;
            try { removeButton = driver.FindElement(By.Id(platformTestData)); } catch { }
            //Unable to find non-selected preference remove button
            Assert.IsNull(removeButton);
        }

        [Test, Order(10)]
        public void Preferences_AddWhenAllPreferencesSelected_NoPreferencesAvailable()
        {
            Logout();
            Login(user: employeeUsername);
            driver.Navigate().GoToUrl(homeURL + changePreferenceUrl);
            IWebElement addButton = null;
            while (true)
            {
                addButton = null;
                try { 
                    addButton = driver.FindElement(By.Id(addCategoryButtonId));
                    addButton.Click();
                } catch { }
                try {
                    addButton = driver.FindElement(By.Id(addPlatformButtonId));
                    addButton.Click();
                } catch { }
                try {
                    addButton = driver.FindElement(By.Id(addSubCategoryButtonId));
                    addButton.Click();
                } catch { }
                if (addButton == null)
                {
                    break;
                }
            }
            try { addButton = driver.FindElement(By.Id(addCategoryButtonId)); } catch { }
            Assert.IsNull(addButton);
            try { addButton = driver.FindElement(By.Id(addPlatformButtonId)); } catch { }
            Assert.IsNull(addButton);
            try { addButton = driver.FindElement(By.Id(addSubCategoryButtonId)); } catch { }
            Assert.IsNull(addButton);
        }
    }
}
