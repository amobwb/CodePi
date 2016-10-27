using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;


namespace Scania.Selenium.Support.Driver
{
    public class Driver
    {
        public IWebDriver driver;

        public IWebDriver driverIE()
        {
            var options = new InternetExplorerOptions();
            //options.ForceCreateProcessApi = true;
            //options.BrowserCommandLineArguments = "-private";
            options.EnsureCleanSession = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.IgnoreZoomLevel = true;
            driver = new InternetExplorerDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }

        public IWebDriver driverChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }


    }
}
