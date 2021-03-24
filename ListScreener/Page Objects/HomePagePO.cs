using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class HomePagePO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By goToAuth = By.XPath("//span[text()='Log in']/parent::*");
        #endregion

        #region IWebElements 
        private IWebElement _goToAuth => _webDriver.FindElement(goToAuth);
        #endregion

        public HomePagePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject ClickLogInButton()
        {
            WaitUntil.WaitElement(_webDriver, goToAuth);
            _goToAuth.Click();

            return new AuthorizationPageObject(_webDriver);
        }
    }
}
