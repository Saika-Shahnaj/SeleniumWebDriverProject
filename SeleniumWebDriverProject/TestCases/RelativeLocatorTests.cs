using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.TestCases
{
    internal class RelativeLocatorTests
    {
        [Test]
        public void InteractionTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            var knownPath = "//h4[text()='Selenium IDE']";

            var rightOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).RightOf(By.XPath(knownPath))).Text;
            var leftOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).LeftOf(By.XPath(knownPath))).Text;
            var belowSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("a")).Below(By.XPath(knownPath))).Text;
            var aboveSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownPath))).Text;

            var h2webElement = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownPath)));

            var chainSample = driver
                .FindElement(RelativeBy.WithLocator(By.TagName("h4"))
                .LeftOf(By.XPath(knownPath))
                .Below(h2webElement))
                .Text;

            var results = new List<string>()
            {
                "[heading] right 'Selenium IDE': " + rightOfSample,
                "[heading] left 'Selenium IDE': " + leftOfSample,
                "[heading] below 'Selenium IDE': " + belowSample,
                "[heading] above 'Selenium IDE': " + aboveSample,
                "[heading] left 'Selenium IDE' and below 'Getting Started': " + chainSample,
            };

            File.WriteAllLines("results", results);


            driver.Quit();
        }
    }
}
