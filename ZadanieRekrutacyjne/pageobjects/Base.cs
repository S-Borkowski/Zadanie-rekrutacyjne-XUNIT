using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ZadanieRekrutacyjne.pageobjects
{
    abstract class Base
    {
        public Base(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetUrl(string name)
        {
            return name switch
            {
                "base_url" => properties.Urls.base_url,
                _ => "no such url or its a typo",
            };
        }

        public void Visit(string name)
        {
            _webDriver.Navigate().GoToUrl(GetUrl(name));
        }

        public void Click(By locator)
        {
            FindElement(locator).Click();
        }

        public void PressEnter(By locator)
        {
            _webDriver.FindElement(locator).SendKeys(Keys.Enter);
        }

        public void Type(By locator, string str)
        {
            FindElement(locator).SendKeys(str);
        }

        public void Hover(By locator)
        {
            Actions action = new Actions(_webDriver);
            action.MoveToElement(FindElement(locator)).Perform();
        }

        public string CheckAttribute(By locator, string attrName)
        {
            return FindElement(locator).GetAttribute(attrName);
        }
        
        public void ScrollTo(By locator)
        {
            var element = _webDriver.FindElement(locator);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public int CountChildren(By locator)
        {
            return _webDriver.FindElements(locator).Count;
        }

        //First waiting method (doesnt work in this case)

        private void WaitForLoad()
        {
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        //Second waiting method (also doesnt work in this case)

        private IWebElement WaitForElement(By locator, int timeout = 5)
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + locator + "' was not found in current context page.");
                throw;
            }
        }

        //Third waiting method

        private bool WaitForLoad(int timeout = 5)
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("/html/body/div[1]")));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element was not found in current context page.");
                throw;
            }
        }

        private IWebElement FindElement(By locator)
        {
            WaitForLoad(5);
            return _webDriver.FindElement(locator);
        }

        private readonly IWebDriver _webDriver;
    }
}
