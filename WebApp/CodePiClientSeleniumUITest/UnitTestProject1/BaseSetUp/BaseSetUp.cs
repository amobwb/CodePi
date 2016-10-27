using NUnit.Framework;
using System.Collections.Generic;
using Scania.Selenium.Support.Actions;
using Scania.Selenium.Support.Driver;
using Scania.Selenium.Support.ErrorHandle;
using CodePiClientSeleniumUITest.PageObject;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;


namespace CodePiClientSeleniumUITest
{
    [TestFixture]
    public class BaseSetUp : Actions
    {
        public CodePi CodePi;
        
        [SetUp]
        public void Setup()
        {
            Driver getDriver = new Driver();
            driver = getDriver.driverChrome();
            
            CodePi = new CodePi(driver);
            
            driver.Navigate().GoToUrl("http:\\vm226440.globaldev.scddev.scania.com");

        }
        
        [TearDown]
        public void TearDown()
        {
            ErrorHandle errorHandle = new ErrorHandle();
            errorHandle.takeScreenshot(driver);
            driver.Close();
            driver.Quit();
        }
    }
}
