using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.TestCases
{
    internal class InteractionTests
    {
        [Test]
        public void InteractionTest()
        {
            var results = new List<string>();
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            //click checkbox
            driver.FindElement(By.Id("my-check-2")).Click();

            //Click radio button
            driver.FindElement(By.Id("my-radio-2")).Click();

            
            var actions = new Actions(driver);

            //right click
            var button = driver.FindElement(By.TagName("button"));
            actions.ContextClick(button).Perform();

            //double click
            var checkbox1 = driver.FindElement(By.Id("my-check-1"));
            actions.DoubleClick();

            //send keys input
            driver.FindElement(By.Id("my-text-id")).SendKeys(Guid.NewGuid().ToString());

            //text area
            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());

            //clear
            textArea.Clear();

            //select
            var selectElement = driver.FindElement(By.Name("my-select"));
            var select = new SelectElement(selectElement);

            select.SelectByText("One");
            select.SelectByValue("2");
            select.SelectByIndex(3);

            //upload
            var filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".text";
            File.WriteAllText(filePath, Guid.NewGuid().ToString());
            driver.FindElement(By.Name("my-file")).SendKeys(filePath);

            driver.Quit();
        }
    }
}
