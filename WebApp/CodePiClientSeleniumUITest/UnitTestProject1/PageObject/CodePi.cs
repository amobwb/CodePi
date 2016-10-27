using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace CodePiClientSeleniumUITest.PageObject
{
    public class CodePi : BaseSetUp
    {
        private IWebDriver driver;
        public CodePi(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "Home")]
        public IWebElement Contact;

        
        //:::Field::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::>

        [FindsBy(How = How.Name, Using = "undermeny1")]
        public IWebElement fieldAnnualMileage;

        

        //::Button::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        [FindsBy(How = How.Name, Using = "button1")]
        public IWebElement buttonAnnualDistanceDeviationAlert;

        

        //::DropDown::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        [FindsBy(How = How.Name, Using = "deopdown1")]
        public IWebElement dropDownLanguage;


    }
}