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

        private readonly By _fieldEmail = By.Id("mat-input-0");
        private readonly By _fieldPassword = By.Id("mat-input-1");
        private readonly By _loginButton = By.XPath("//span[@class='mat-button-wrapper']");
        



        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public HomePagePageObject SignIn(string login, string password)
        {
            _webDriver.FindElement(_fieldEmail).SendKeys(login);
            _webDriver.FindElement(_fieldPassword).SendKeys(password);
            _webDriver.FindElement(_loginButton).Click();

            return new HomePagePageObject(_webDriver);
        }
    }
}
