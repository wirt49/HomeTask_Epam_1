using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HomeTask_Epam_1
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly string url = "https://www.google.com.ua/?hl=uk";
        private readonly string searchedWord = "audi";
        private readonly By searchFieldXpath = By.XPath("//input[@name = 'q']");
        private readonly By imageButtonPath = By.XPath("//div[@class = 'hdtb-mitem']/a[contains(@data-hveid, 'CAIQAw')]");
        private readonly By allImagesOnThePagePath = By.XPath("//div[@class= 'bRMDJf islir']");
        private readonly By searchedImagePath = By.XPath("//div[@id = 'Sva75c']");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var searchField = driver.FindElement(searchFieldXpath);
            searchField.SendKeys(searchedWord);
            searchField.Submit();
            var imageButton = driver.FindElement(imageButtonPath);
            imageButton.Click();
            var imagesOnPage = driver.FindElements(allImagesOnThePagePath);

            imagesOnPage[0].Click();

            var searchedImage = driver.FindElement(searchedImagePath);
            bool isSearchedImageDisplayed = searchedImage.Displayed;

            Assert.IsTrue(isSearchedImageDisplayed);

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}