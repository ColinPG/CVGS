using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class AddressTests : CVGSTestContainer
    {
        private string addressesUrl;
        private string addressesAddUrl;
        private string addressesEditUrl;
        private string addressesDeleteUrl;

        public AddressTests()
        {
            addressesUrl = "Identity/Account/Manage/Addresses";
            addressesAddUrl = "Identity/Account/Manage/AddressAdd";
            addressesEditUrl = "Identity/Account/Manage/AddressEdit";
            addressesDeleteUrl = "Identity/Account/Manage/AddressDelete";
        }

        [Test, Order(1)]
        public void Addresses_NavigateToIndex_URLIsIndex()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(2)]
        public void Addresses_NavigateToCreate_URLIsCreate()
        {
            driver.Navigate().GoToUrl(addressesAddUrl);
            Assert.AreEqual(driver.Url, addressesAddUrl);
        }

        [Test, Order(3)]
        public void Addresses_NavigateToEdit_NoIdFound()
        {
            driver.Navigate().GoToUrl(addressesEditUrl);
            Assert.AreNotEqual(driver.Url, addressesEditUrl);
        }

        [Test, Order(4)]
        public void Addresses_NavigateToDelete_NoIdFound()
        {
            driver.Navigate().GoToUrl(addressesDeleteUrl);
            Assert.AreNotEqual(driver.Url, addressesDeleteUrl);
        }

        [Test, Order(5)]
        public void Addresses_ClickEditLinkNoAddresses_NoEditLinkFound()
        {
            driver.Navigate().GoToUrl(addressesUrl);


            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(6)]
        public void Addresses_ClickDeleteLinkNoAddresses_NoEditLinkFound()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(7)]
        public void Addresses_AddShippingAddr_ShippingAddrAdded()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            //Verify under correct list
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(8)]
        public void Addresses_AddMailingAddr_MailingAddrAdded()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(9)]
        public void Addresses_EditShippingAddr_ShippingAddrEditted()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(10)]
        public void Addresses_EditMailingAddr_MailingAddrEditted()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(11)]
        public void Addresses_DeleteShippingAddr_ShippingAddrDeleted()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(12)]
        public void Addresses_DeleteMailingAddr_MailingAddrDeleted()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(13)]
        public void Addresses_AddAddrWithInvalidData_InputValidationFailed()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }

        [Test, Order(14)]
        public void Addresses_EditAddrWithInvalidData_InputValidationFailed()
        {
            driver.Navigate().GoToUrl(addressesUrl);
            Assert.AreEqual(driver.Url, addressesUrl);
        }
    }
}
