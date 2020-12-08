using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CVGS.Tests
{
    class GameLibraryTests : CVGSTestContainer
    {
        private readonly string libraryURL;
        public GameLibraryTests()
        {
            libraryURL = "Identity/Account/GameLibrary";
        }

        [Test]
        public void GameLibrary_NavigateToLibraryAsMember_URLIsLibrary()
        {
            LoginAsMember();
            IWebElement library = driver.FindElement(By.LinkText("Library"));
            library.Click();
            Assert.AreEqual(driver.Url, homeURL + libraryURL);
        }

        [Test]
        public void GameLibrary_NavigateToLibraryAsEmployee_URLIsNotLibrary()
        {
            LoginAsEmployee();
            IWebElement library = null;
            try { library = driver.FindElement(By.LinkText("Library")); } catch { }
            Assert.IsNull(library);
        }

        [Test]
        public void GameLibrary_CheckForGameDownloadLink_DownloadLinkFound()
        {
            //Warning: This test assumes a game is already purchased on TestMember1 account
            LoginAsMember();
            IWebElement library = driver.FindElement(By.LinkText("Library"));
            library.Click();
            IWebElement downloadLink = driver.FindElement(By.LinkText("Download"));
            Assert.IsNotNull(downloadLink);
        }

        [Test]
        public void GameLibrary_DownloadFile_FileExistsOnLocalMachine()
        {
            driver.Close();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--browser.download.folderList=2");
            chromeOptions.AddArguments("--browser.helperApps.neverAsk.saveToDisk=text/plain");
            chromeOptions.AddArguments("--browser.download.dir=" + downloadPath);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            driver = new ChromeDriver(chromeOptions);
            Login(user: memberUsername);
            IWebElement library = driver.FindElement(By.LinkText("Library"));
            library.Click();
            IWebElement game = driver.FindElement(By.Id("gameName"));
            string gameName = game.Text;
            IWebElement downloadLink = driver.FindElement(By.LinkText("Download"));
            string path = downloadLink.GetAttribute("href");
            driver.Navigate().GoToUrl(path);

            var timeAtPause = DateTime.Now;
            var seconds = TimeSpan.FromSeconds(3);
            var wait = new WebDriverWait(driver, seconds);
            wait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            wait.Until(wd => (DateTime.Now - timeAtPause) - seconds > TimeSpan.Zero);
            string finalPath = downloadPath + "\\" + gameName + ".txt";
            Assert.True(File.Exists(finalPath));
            StreamReader reader = File.OpenText(finalPath);
            Assert.AreEqual(reader.ReadLine(), "Title: " + gameName);
            reader.Close();
            File.Delete(finalPath);
        }
    }
}
