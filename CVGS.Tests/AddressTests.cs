using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    public class AddressTests : CVGSTestContainer
    {
        private string addressesUrl;
        private string addressesAddUrl;
        private string addressesEditUrl;
        private string addressesDeleteUrl;

        private const string editLinkText = "Edit";
        private const string deleteLinkText = "Delete";
        private const string addShippingLinkText = "Add Shipping Address";
        private const string addMailingLinkText = "Add Mailing Address";
        private string testShippingGuid;
        private string testMailingGuid;

        public AddressTests()
        {
            addressesUrl = "Identity/Account/Manage/Addresses";
            addressesAddUrl = "Identity/Account/Manage/AddressAdd";
            addressesEditUrl = "Identity/Account/Manage/AddressEdit";
            addressesDeleteUrl = "Identity/Account/Manage/AddressDelete";
        }

        [Test, Order(1)]
        public void Addresses_NavigateToAddressIndex_URLIsAddressIndex()
        {
            IWebElement profile = driver.FindElement(By.LinkText("Profile"));
            profile.Click();
            IWebElement addresses = driver.FindElement(By.LinkText("Addresses"));
            addresses.Click();
            Assert.AreEqual(driver.Url, homeURL + addressesUrl);
        }

        [Test, Order(2)]
        public void Addresses_NavigateToAdd_URLIsAdd()
        {
            driver.Navigate().GoToUrl(homeURL + addressesAddUrl);
            Assert.AreEqual(driver.Url, homeURL + addressesAddUrl);
        }

        [Test, Order(3)]
        public void Addresses_NavigateToEdit_NoIdFound()
        {
            driver.Navigate().GoToUrl(homeURL + addressesEditUrl);
            Assert.AreNotEqual(driver.Url, homeURL + addressesEditUrl);
        }

        [Test, Order(4)]
        public void Addresses_NavigateToDelete_NoIdFound()
        {
            driver.Navigate().GoToUrl(homeURL + addressesDeleteUrl);
            Assert.AreNotEqual(driver.Url, homeURL + addressesDeleteUrl);
        }

        //Testing with Default login, if test failed likely leftover address in Default login.
        [Test, Order(5)]
        public void Addresses_ClickEditLinkNoAddresses_NoEditLinkFound()
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            IWebElement editLink = null;
            try
            {
                editLink = driver.FindElement(By.LinkText(editLinkText));
            }
            catch { }
            Assert.IsNull(editLink);
        }

        //Testing with Default login, if test failed likely leftover address in Default login.
        [Test, Order(6)]
        public void Addresses_ClickDeleteLinkNoAddresses_NoEditLinkFound()
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            IWebElement deleteLink = null;
            try
            {
                deleteLink = driver.FindElement(By.LinkText(deleteLinkText));
            }
            catch { }
            Assert.IsNull(deleteLink);
        }

        [TestCase("TestFirstName","TestLastName","TestAptNum","TestStreet","TestCity","N2R1W2","TestProvince")]
        [Test, Order(7)]
        public void Addresses_AddShippingAddr_ShippingAddrAdded(string fName, string lName, string aptNum, string street, string city, string postal, string province)
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            //Add Address Info
            IWebElement addShippingLink = driver.FindElement(By.LinkText(addShippingLinkText));
            addShippingLink.Click();
            //Input_FirstName
            IWebElement FirstName = driver.FindElement(By.Id("Input_FirstName"));
            FirstName.SendKeys(fName);
            //Input_LastName
            IWebElement lastName = driver.FindElement(By.Id("Input_LastName"));
            lastName.SendKeys(lName);
            //Input_ApartmentNumber
            IWebElement apartmentNumber = driver.FindElement(By.Id("Input_ApartmentNumber"));
            apartmentNumber.SendKeys(aptNum);
            //Input_Street
            IWebElement streetBox = driver.FindElement(By.Id("Input_Street"));
            streetBox.SendKeys(street);
            //Input_City
            IWebElement cityBox = driver.FindElement(By.Id("Input_City"));
            cityBox.SendKeys(city);
            //Input_Street
            IWebElement postalCode = driver.FindElement(By.Id("Input_PostalCode"));
            postalCode.SendKeys(postal);
            //Input_Street
            IWebElement provinceBox = driver.FindElement(By.Id("Input_Province"));
            provinceBox.SendKeys(province);

            //SubmitButton
            IWebElement addButton = driver.FindElement(By.Id("add-address"));
            addButton.Click();
            //Verify exists, and under correct list
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText(editLinkText));
            Assert.IsNotNull(elements);
            foreach (IWebElement e in elements)
            {
                string[] words = e.GetAttribute("id").Split("_");
                Assert.AreEqual(words[0], "EditS");
                testShippingGuid = words[1];
            }
        }

        [TestCase("TestFirstName", "TestLastName", "TestAptNum", "TestStreet", "TestCity", "N2R1W2", "TestProvince")]
        [Test, Order(8)]
        public void Addresses_AddMailingAddr_MailingAddrAdded(string fName, string lName, string aptNum, string street, string city, string postal, string province)
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            //Add Address Info
            IWebElement addMailingLink = driver.FindElement(By.LinkText(addMailingLinkText));
            addMailingLink.Click();
            //Input_FirstName
            IWebElement FirstName = driver.FindElement(By.Id("Input_FirstName"));
            FirstName.SendKeys(fName);
            //Input_LastName
            IWebElement lastName = driver.FindElement(By.Id("Input_LastName"));
            lastName.SendKeys(lName);
            //Input_ApartmentNumber
            IWebElement apartmentNumber = driver.FindElement(By.Id("Input_ApartmentNumber"));
            apartmentNumber.SendKeys(aptNum);
            //Input_Street
            IWebElement streetBox = driver.FindElement(By.Id("Input_Street"));
            streetBox.SendKeys(street);
            //Input_City
            IWebElement cityBox = driver.FindElement(By.Id("Input_City"));
            cityBox.SendKeys(city);
            //Input_Street
            IWebElement postalCode = driver.FindElement(By.Id("Input_PostalCode"));
            postalCode.SendKeys(postal);
            //Input_Street
            IWebElement provinceBox = driver.FindElement(By.Id("Input_Province"));
            provinceBox.SendKeys(province);

            //SubmitButton
            IWebElement addButton = driver.FindElement(By.Id("add-address"));
            addButton.Click();
            //Verify exists, and under correct list
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText(editLinkText));
            Assert.IsNotNull(elements);
            foreach (IWebElement e in elements)
            {
                string[] words = e.GetAttribute("id").Split("_");
                Assert.AreEqual(words[0], "EditM");
                testMailingGuid = words[1];
                break;
            }
        }

        [TestCase("", "TestLastName", "TestAptNum", "TestStreet", "TestCity", "N2R1W2", "TestProvince")]
        [TestCase("", "", "", "", "", "", "")]
        [Test, Order(9)]
        public void Addresses_AddAddrWithInvalidData_InputValidationFailed(string fName, string lName, string aptNum, string street, string city, string postal, string province)
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            //Add Address Info
            IWebElement addMailingLink = driver.FindElement(By.LinkText(addMailingLinkText));
            addMailingLink.Click();
            //Input_FirstName
            IWebElement FirstName = driver.FindElement(By.Id("Input_FirstName"));
            FirstName.SendKeys(fName);
            //Input_LastName
            IWebElement lastName = driver.FindElement(By.Id("Input_LastName"));
            lastName.SendKeys(lName);
            //Input_ApartmentNumber
            IWebElement apartmentNumber = driver.FindElement(By.Id("Input_ApartmentNumber"));
            apartmentNumber.SendKeys(aptNum);
            //Input_Street
            IWebElement streetBox = driver.FindElement(By.Id("Input_Street"));
            streetBox.SendKeys(street);
            //Input_City
            IWebElement cityBox = driver.FindElement(By.Id("Input_City"));
            cityBox.SendKeys(city);
            //Input_Street
            IWebElement postalCode = driver.FindElement(By.Id("Input_PostalCode"));
            postalCode.SendKeys(postal);
            //Input_Street
            IWebElement provinceBox = driver.FindElement(By.Id("Input_Province"));
            provinceBox.SendKeys(province);
            //SubmitButton
            IWebElement addButton = driver.FindElement(By.Id("add-address"));
            addButton.Click();
            Assert.AreNotEqual(homeURL + addressesAddUrl, driver.Url);
        }

        [Test, Order(10)]
        public void Addresses_EditAddrWithInvalidData_InputValidationFailed()
        {
            string editTestShipAddressURL = homeURL + addressesEditUrl + "?id=" + testShippingGuid + "&isMailing=false";
            driver.Navigate().GoToUrl(editTestShipAddressURL);
            //Input_FirstName
            IWebElement firstName = driver.FindElement(By.Id("Input_FirstName"));
            string newFName = ""; //First Name can't be blank
            firstName.Clear();
            firstName.SendKeys(newFName);
            //SubmitButton
            IWebElement editButton = driver.FindElement(By.Id("edit-address"));
            editButton.Click();

            driver.Navigate().GoToUrl(editTestShipAddressURL);
            firstName = driver.FindElement(By.Id("Input_FirstName"));
            Assert.AreNotEqual(newFName, firstName.GetAttribute("value"));
        }

        [Test, Order(11)]
        public void Addresses_EditShippingAddr_ShippingAddrEditted()
        {
            string editTestShipAddressURL = homeURL + addressesEditUrl + "?id=" + testShippingGuid + "&isMailing=false";
            driver.Navigate().GoToUrl(editTestShipAddressURL);
            //Input_FirstName
            IWebElement firstName = driver.FindElement(By.Id("Input_FirstName"));
            string newFName = firstName.GetAttribute("value").Substring(0, firstName.GetAttribute("value").Length - 1);
            firstName.Clear();
            firstName.SendKeys(newFName);
            //SubmitButton
            IWebElement editButton = driver.FindElement(By.Id("edit-address"));
            editButton.Click();

            driver.Navigate().GoToUrl(editTestShipAddressURL);
            firstName = driver.FindElement(By.Id("Input_FirstName"));
            Assert.AreEqual(newFName, firstName.GetAttribute("value"));
        }

        [Test, Order(12)]
        public void Addresses_EditMailingAddr_MailingAddrEditted()
        {
            string editTestShipAddressURL = homeURL + addressesEditUrl + "?id=" + testMailingGuid + "&isMailing=true";
            driver.Navigate().GoToUrl(editTestShipAddressURL);
            //Input_FirstName
            IWebElement firstName = driver.FindElement(By.Id("Input_FirstName"));
            string newFName = firstName.GetAttribute("value").Substring(0, firstName.GetAttribute("value").Length - 1);
            firstName.Clear();
            firstName.SendKeys(newFName);
            //SubmitButton
            IWebElement editButton = driver.FindElement(By.Id("edit-address"));
            editButton.Click();

            driver.Navigate().GoToUrl(editTestShipAddressURL);
            firstName = driver.FindElement(By.Id("Input_FirstName"));
            Assert.AreEqual(newFName, firstName.GetAttribute("value"));
        }

        [Test, Order(13)]
        public void Addresses_DeleteShippingAddr_ShippingAddrDeleted()
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText(deleteLinkText));
            Assert.IsNotNull(elements);
            foreach (IWebElement e in elements)
            {
                string[] words = e.GetAttribute("id").Split("_");
                if (words[0] == "DeleteS")
                {
                    e.Click();
                    break;
                }
            }
            string deleteUrl = driver.Url;
            IWebElement deleteButton = driver.FindElement(By.Id("delete-address"));
            deleteButton.Click();

            driver.Navigate().GoToUrl(deleteUrl);
            Assert.AreNotEqual(deleteUrl, driver.Url);
        }

        [Test, Order(14)]
        public void Addresses_DeleteMailingAddr_MailingAddrDeleted()
        {
            driver.Navigate().GoToUrl(homeURL + addressesUrl);
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.LinkText(deleteLinkText));
            Assert.IsNotNull(elements);
            foreach (IWebElement e in elements)
            {
                string[] words = e.GetAttribute("id").Split("_");
                if (words[0] == "DeleteM")
                {
                    e.Click();
                    break;
                }
            }
            string deleteUrl = driver.Url;
            IWebElement deleteButton = driver.FindElement(By.Id("delete-address"));
            deleteButton.Click();

            driver.Navigate().GoToUrl(deleteUrl);
            Assert.AreNotEqual(deleteUrl, driver.Url);
        }
    }
}
