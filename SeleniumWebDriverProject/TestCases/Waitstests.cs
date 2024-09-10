using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.TestCases
{
    internal class Waitstests
    {
        [Test]
        public void ImplecitWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Quit();
        }


        [Test]
        public void ExplicitWaitTest()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

            //Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var condition1 = wait.Until(e => e.Title == "Web form");
            var condition2 = wait.Until(e => e.FindElement(By.Name("my-textarea")));
            var condition3 = wait.Until(e => e.FindElement(By.Name("my-textarea")).Displayed);

            driver.Quit();

        }


        [Test]
        public void fluentWaitTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");


            //wait ignore exception
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };

            wait.IgnoreExceptionTypes(typeof(HttpRequestException));

            var condition = wait.Until(e => e.Title == "Web form");

            var textArea = driver.FindElement(By.Name("my-textarea"));
            textArea.SendKeys(Guid.NewGuid().ToString());


            driver.Quit();

        }

    }
    
}
