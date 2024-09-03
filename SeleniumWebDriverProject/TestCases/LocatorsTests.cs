using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.TestCases
{
    internal class LocatorsTests
    {
        [Test]

        public void LocatorTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));
            //class name
            //var classNameValidator = driver.FindElement(By.XPath("//li/div/a[@class='nav-link dropdown-toggle']")).Displayed;
             var classNameValidator = driver.FindElement(By.ClassName("alert-heading")).Displayed;
            Assert.That(classNameValidator, Is.EqualTo(true));

            //css seclector
            var cssSelectorValidator = driver.FindElement(By.CssSelector(".alert-heading")).Displayed;
            Assert.That(cssSelectorValidator, Is.EqualTo(true));

            //id selector
            var idValidator = driver.FindElement(By.Id("Layer_1")).Displayed;
            Assert.That(idValidator, Is.EqualTo(true));

            //name selector
            //var nameValidator = driver.FindElement(By.Name("viewport")).Displayed;
            //Assert.That(nameValidator, Is.EqualTo(true));

            //Link text
            var linkTextValidator = driver.FindElement(By.LinkText("Documentation")).Displayed;
            Assert.That(linkTextValidator, Is.EqualTo(true));

            //Partial link text
            var partialLinkTextValidator = driver.FindElement(By.PartialLinkText("Doc")).Displayed;
            Assert.That(partialLinkTextValidator, Is.EqualTo(true));

            //Tag
            var tagValidator = driver.FindElement(By.TagName("nav")).Displayed;
            Assert.That(tagValidator, Is.EqualTo(true));

            //XPath
            var xpathValidator = driver.FindElement(By.XPath("//h1")).Displayed;
            Assert.That(xpathValidator, Is.EqualTo(true));

            driver.Quit();
        }
    }
}
