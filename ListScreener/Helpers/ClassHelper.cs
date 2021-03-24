using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListScreener.Page_Objects
{
    class ClassHelper
    {
        protected IWebDriver _webDriver;

        #region XPath
        private readonly By inputSearch = By.XPath("//input[@type='search']");

        public ClassHelper(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        #endregion

        #region IWebElements 
        private IWebElement _inputSearch => _webDriver.FindElement(inputSearch);

        #endregion

        public void InputSearch(string text)
        {
            _inputSearch.SendKeys(text);

        }

        public bool isElementDisplayed(IWebElement webElement)
        {
            try
            {
                return webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public ClassHelper OpenNewTab()
        {
            WaitUntil.WaitSomeInterval(1);
            ((IJavaScriptExecutor)_webDriver).ExecuteScript("window.open();");
            return this;
        }

        public void MoveFirstTab()
        {
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.First());
        }

        public ClassHelper MoveLastTab()
        {
            WaitUntil.WaitSomeInterval(1);
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
            return this;
        }

        public void GoToURL(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }


    }
}
