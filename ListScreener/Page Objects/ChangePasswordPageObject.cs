using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ListScreener.Page_Objects
{
    class ChangePasswordPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _currentPassword = By.XPath("//input[@formcontrolname='password']");
        private readonly By _newPassword = By.XPath("//input[@formcontrolname='newPassword']");
        private readonly By _confirmNewPassword = By.XPath("//input[@formcontrolname='repeatPassword']");
        private readonly By _changeButton = By.XPath("//span[text()='Change']");

        public ChangePasswordPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountPageObject ChangePasswordForm(string currentPassword, string newPassword, string confirmNewPassword)
        {
            _webDriver.FindElement(_currentPassword).SendKeys(currentPassword);
            _webDriver.FindElement(_newPassword).SendKeys(newPassword);
            _webDriver.FindElement(_confirmNewPassword).SendKeys(confirmNewPassword);
            _webDriver.FindElement(_changeButton).Click();

            return new AccountPageObject(_webDriver);
        }

        public AccountPageObject ChangePasswordBack(string newPassword, string currentPassword, string confirmNewPassword)
        {
            WaitUntil.WaitSomeInterval(2);
            _webDriver.FindElement(_currentPassword).SendKeys(newPassword);

            WaitUntil.WaitElement(_webDriver, _newPassword);
            _webDriver.FindElement(_newPassword).SendKeys(currentPassword);
          
            _webDriver.FindElement(_confirmNewPassword).SendKeys(confirmNewPassword);
            _webDriver.FindElement(_changeButton).Click();

            WaitUntil.WaitSomeInterval();

            return new AccountPageObject(_webDriver);
        }
    }
}
