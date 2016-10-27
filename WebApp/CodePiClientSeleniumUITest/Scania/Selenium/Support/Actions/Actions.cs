using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Scania.Selenium.Support.Actions
{

    public class Actions
    {
        public IWebDriver driver;

        public Actions(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public Actions()
        {}

        // To wait:

        public static void WaitForElement(IWebElement element, int maxWaitTimeInSeconds, IWebDriver driver)
        {
            //IWebDriver driver = GetDriver();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

            wait.Until(d =>
            {

                try
                {
                    IWebElement WhatToWait = element;
                    return true;
                }

                catch (NoSuchElementException ex)
                {
                    throw new NoSuchElementException("Something wrong:", ex);
                }

            });

        }

        public static void WaitForPageLoad(int maxWaitTimeInSeconds, IWebDriver driver)
        {

            string state = string.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

                //Checks every 500 ms whether predicate returns true if returns exit otherwise keep trying till it returns true
                wait.Until(d =>
                {

                    try
                    {
                        state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                    }
                    catch (InvalidOperationException)
                    {
                        //Ignore
                    }
                    catch (NoSuchWindowException)
                    {
                        //when popup is closed, switch to last windows
                        //driver.SwitchTo().Window();
                    }
                    //In IE7 there are chances we may get state as loaded instead of complete
                    return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase));

                });
            }
            catch (TimeoutException)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
                if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                    throw;
            }
            catch (NullReferenceException)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls
                if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                    throw;
            }
            catch (WebDriverException)
            {
                if (driver.WindowHandles.Count == 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
                state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                if (!(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase)))
                    throw;
            }
        }

        public static void WaitAndSwitchToAlert(int maxWaitTimeInSeconds, IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

            wait.Until(d =>
            {

                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }

                catch (NoAlertPresentException ex)
                {
                    throw new NoAlertPresentException("Something wrong:", ex);
                }

            });

        }

        public static void WaitSwitchToAlertAndAccept(int maxWaitTimeInSeconds, IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

            wait.Until(d =>
            {

                try
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }

                catch (NoAlertPresentException ex)
                {
                    throw new NoAlertPresentException("Something wrong:", ex);
                }

            });


        }

        // To write: 

        public static void writeTextToField(string inputText, IWebElement element)
        {
            element.Clear();
            element.SendKeys(inputText);
        }

        // Manage windows:

        public static string RememberMyCurrentWindow(IWebDriver driver)
        {
            string currentWindow = driver.CurrentWindowHandle;
            return currentWindow;
        }

        public static void SwitchToWindow(string windowOne, string title, IWebDriver driver)
        {

            WaitForPageLoad(5, driver);

            ReadOnlyCollection<string> handles = driver.WindowHandles;

            foreach (string handle in handles)
            {

                if (handle != windowOne)
                {
                    if (driver.SwitchTo().Window(handle).Title.Contains(title))
                        break;
                }
            }
        }

        // Working with pages:

        public static void verifyPageTitle(string pageTitle, IWebDriver driver)
        {

            if (driver.Title != pageTitle)
                throw new NoSuchWindowException("This is not the: " + pageTitle + "page" + " This is: " + driver.Title);
        }

        // Working with drop-down

        public static void selectFromDropDownByText(string inputText, IWebElement dropDown)
        {
            SelectElement list = new SelectElement(dropDown);
            list.SelectByText(inputText);
        }

        public string getTextSelectedInDropDown(IWebElement dropDown)
        {
            SelectElement select = new SelectElement(dropDown);
            var option = select.SelectedOption;
            string selectedElement = option.Text;

            return selectedElement;
        }

        // Working with the similar objects

        public IWebElement searchElementByTextInList(string textInAlert, IList<IWebElement> allElements)
        {
            IWebElement myAlert = null;

            foreach (IWebElement element in allElements)
            {
                string text = element.Text.Replace("\"", "");

                if (text.Equals(textInAlert))
                {
                    myAlert = element;
                }
            }

            return myAlert;
        }

        public IWebElement searchElementByText(string elementHasText, IList<IWebElement> allElements)
        {
            IWebElement myElement = null;

            foreach (IWebElement element in allElements)
            {

                if (element.Text.Equals(elementHasText))
                {
                    myElement = element;
                }
            }

            return myElement;
        }

    }
}
