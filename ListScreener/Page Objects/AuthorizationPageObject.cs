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

        private readonly By _fieldEmail = By.XPath("//input[@formcontrolname='email']");
        private readonly By _fieldPassword = By.XPath("//input[@formcontrolname='password']");
        private readonly By _loginButton = By.XPath("//span[text()='Log in']");

        



        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public HomePagePageObject SignIn(string login, string password)
        {
            _webDriver.FindElement(_fieldEmail).SendKeys(login);
            _webDriver.FindElement(_fieldPassword).SendKeys(password);
            _webDriver.FindElement(_loginButton).Click();
            Thread.Sleep(1500);

            return new HomePagePageObject(_webDriver);
        }
    }
}
