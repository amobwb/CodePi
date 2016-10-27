using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using Scania.Selenium.Support.Actions;


namespace CodePiClientSeleniumUITest.TestCase
{
    [TestFixture]
    public class TestCase : BaseSetUp
    {
             
        [Test]
        public void Test_CodePi()
        {
            IWebDriver driver = null;
            try
            {
                TestAddEmployee(driver);
            }
            catch (Exception ex) { }
            finally
            {
                driver.Quit();
            }

        }


        private void TestAddEmployee(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Contact")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => { return d.FindElement(By.Id("Name")); });

            IWebElement name = driver.FindElement(By.Id("Name"));
            IWebElement sal = driver.FindElement(By.Id("Sal"));
            IWebElement submit = driver.FindElement(By.Id("Submit"));

            name.SendKeys("Affe");
            sal.SendKeys("5000");
            submit.Click();

            IAlert alert = null;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { alert = d.SwitchTo().Alert(); return alert; });
            alert.Accept();
        }
    }
}
    



