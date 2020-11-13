using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVGS.Tests
{
    class HomeControllerTests : CVGSTestContainer
    {
        [Test]
        public void HomeController_NavigateToIndex_URLIsIndex()
        {
            driver.Navigate().GoToUrl(homeURL);
            Assert.AreEqual(driver.Url, homeURL);
        }
    }
}
