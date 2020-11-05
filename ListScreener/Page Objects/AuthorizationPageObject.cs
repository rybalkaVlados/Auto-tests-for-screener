using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By fieldEmail = By.XPath("//input[@formcontrolname='email']");
        private readonly By fieldPassword = By.XPath("//input[@formcontrolname='password']");
        private readonly By loginButton = By.XPath("//span[text()='Log in']");
        #endregion

        #region IWebElements 
        private IWebElement _fieldEmail => _webDriver.FindElement(fieldEmail);
        private IWebElement _fieldPassword => _webDriver.FindElement(fieldPassword);
        private IWebElement _loginButton => _webDriver.FindElement(loginButton);
        #endregion




        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public HomePagePageObject SignIn(string login, string password)
        {
            WaitUntil.WaitElement(_webDriver, fieldEmail);
            _fieldEmail.SendKeys(login);
            _fieldPassword.SendKeys(password);
            _loginButton.Click();
            Thread.Sleep(1500);

            return new HomePagePageObject(_webDriver);
        }
    }
}
