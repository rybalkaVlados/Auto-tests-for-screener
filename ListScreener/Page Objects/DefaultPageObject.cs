using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class DefaultPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _goToAuth = By.XPath("//span[text()='Log in']/parent::*");




        public DefaultPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject LogIn()
        {
            WaitUntil.WaitElement(_webDriver, _goToAuth);
            _webDriver.FindElement(_goToAuth).Click();

            return new AuthorizationPageObject(_webDriver);
        }
    }
}
