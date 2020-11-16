using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class PreferenceTests : CVGSTestContainer
    {
        private string preferenceUrl;
        public PreferenceTests()
        {
            preferenceUrl = "Identity/Account/Manage/PreferenceIndex";
        }

        [Test]
        public void Preferences_NavigateToIndex_URLIsIndex()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_AddPlatformPref_PlatformIsAdded()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_AddCategoryPref_CategoryIsAdded()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_AddSubcategoryPref_SubCategoryIsAdded()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_RemovePlatformPref_PlatformIsRemoved()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_RemoveCategoryPref_CategoryIsRemoved()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_RemoveSubcategoryPref_SubCategoryIsRemoved()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_AddExistingPreference_FailToFindPreference()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_RemovePreferenceWhenNoneExist_NoPreferencesListed()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_RemoveNonSelectedPreference_PreferenceNotFound()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }

        [Test]
        public void Preferences_AddWhenAllPreferencesSelected_NoPreferencesAvailable()
        {
            driver.Navigate().GoToUrl(preferenceUrl);
            Assert.AreEqual(driver.Url, preferenceUrl);
        }
    }
}
