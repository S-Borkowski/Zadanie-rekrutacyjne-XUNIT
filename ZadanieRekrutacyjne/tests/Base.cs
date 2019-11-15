using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace ZadanieRekrutacyjne.tests
{
    public abstract class Base
    {
        public void SetUpBrowser(string browserName)
        {
            switch (browserName) 
            {
                case "chrome":
                    try
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        options.AddUserProfilePreference("download.prompt_for_download", false);
                        webDriver = new ChromeDriver(options);
                        webDriver.Manage().Window.FullScreen();
                        Console.WriteLine("Starting browser...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception while starting browser..." + e);
                    }; 
                    break;
                case "firefox":
                    try
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        options.AddArguments("-headless");
                        options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/zip");
                        webDriver = new FirefoxDriver(options);
                        webDriver.Manage().Window.FullScreen();
                        Console.WriteLine("Starting browser...");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception while starting browser..." + e);
                    };
                    break;
                default:
                    Console.WriteLine("Invalid browser name");
                    break;
            }
        }

        public void TearDown()
        {
            webDriver.Dispose();
        }

        public static IWebDriver webDriver;
    }
}
