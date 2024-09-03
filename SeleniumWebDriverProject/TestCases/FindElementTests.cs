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
    internal class FindElementTests
    {
        [Test]

        public void LocatorTest()
        {
            var results = new List<string>();
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            //findElement
            var firstH2 = driver.FindElement(By.XPath("//h2"));
            results.Add($"FindElements: {firstH2.Text}");

            //findElements
            var h2Colleaction = driver.FindElements(By.XPath("//h2"));
            foreach(var h2 in h2Colleaction)
            {
                results.Add($"FindElements: { h2.Text}");
            }

            //evalute a subset of the DOM
            var parentElement = driver.FindElement(By.CssSelector("div[id='main_navbar']"));
            var links = parentElement.FindElements(By.TagName("a"));
            foreach(var link in links)
            {
                var result = link.Text;
                if (!string.IsNullOrEmpty(result))
                {
                    results.Add($"links: {link.Text}");
                }
            }

            File.WriteAllLines("results", results);

            driver.Quit();
        }
    }
}
