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
        private readonly By btnLogIn = By.XPath("//span[text()='Log in']");
        private readonly By btnRegisterNow = By.XPath("//a[text()='Register now']");

        #endregion

        #region IWebElements 
        private IWebElement _fieldEmail => _webDriver.FindElement(fieldEmail);
        private IWebElement _fieldPassword => _webDriver.FindElement(fieldPassword);
        private IWebElement _btnLogIn => _webDriver.FindElement(btnLogIn);
        private IWebElement _btnRegisterNow => _webDriver.FindElement(btnRegisterNow);
        #endregion




        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public CompaniesPagePO SignIn(string login, string password)
        {
            WaitUntil.WaitElement(_webDriver, fieldEmail);
            _fieldEmail.SendKeys(login);
            _fieldPassword.SendKeys(password);
            _btnLogIn.Click();
            Thread.Sleep(1500);

            return new CompaniesPagePO(_webDriver);
        }

        public RegisterFormPO ClickRegisterNow()
        {
            WaitUntil.WaitElement(_webDriver, btnRegisterNow);
            _btnRegisterNow.Click();
            return new RegisterFormPO(_webDriver);
        }
    }
}
